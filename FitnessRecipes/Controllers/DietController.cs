using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Helpers;
using FitnessRecipes.ViewModels;
using System.Linq;

namespace FitnessRecipes.Controllers
{
    public class DietController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDietCategoryRepository _categoryRepository;
        private readonly IDietMealRepository _dietMealRepository;
        private readonly IDietIngredientRepository _dietIngredientRepository;
        private readonly IQuantityTypeRepository _quantityTypeRepository;
        private readonly IDietRepository _dietRepository;
        private readonly IUserDietRepository _userDietRepository;

        public DietController(IDietRepository dietRepository, ICommentRepository commentRepository, IUserRepository userRepository, IDietCategoryRepository categoryRepository,
            IDietMealRepository dietMealRepository, IDietIngredientRepository dietIngredientRepository, IQuantityTypeRepository quantityTypeRepository,
            IUserDietRepository userDietRepository)
        {
            _dietRepository = dietRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _dietMealRepository = dietMealRepository;
            _dietIngredientRepository = dietIngredientRepository;
            _quantityTypeRepository = quantityTypeRepository;
            _userDietRepository = userDietRepository;
        }

        public ActionResult Index()
        {
            var diets = Mapper.Map<IEnumerable<Diet>, IEnumerable<DietViewModel>>(_dietRepository.GetAll());
            const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var alfabetDic = alfabet.ToDictionary(t => t, t => diets.Where(diett => diett.Name.ToUpper()[0] == t).ToList());
            return View(alfabetDic);
        }

        public ActionResult Details(int id)
        {
            var diet = _dietRepository.Get(id);
            var dietViewModel = Mapper.Map<Diet, DietViewModel>(diet);
            var dietCalculator = new DietCalculator(diet);
            dietViewModel.Ingredients = Mapper.Map<IEnumerable<DietIngredient>, IEnumerable<DietIngredientViewModel>>(diet.DietIngredients);
            dietViewModel.Meals = Mapper.Map<IEnumerable<DietMeal>, IEnumerable<DietMealViewModel>>(diet.DietMeals);
            dietViewModel.Kcal = dietCalculator.CalculateAverageKcal();
            dietViewModel.Fat = dietCalculator.CalculateFatPercentage();
            dietViewModel.Carb = dietCalculator.CalculateCarbPercentage();
            dietViewModel.Protein = dietCalculator.CalculateProteinPercentage();
            return View(dietViewModel);
        }

        public ActionResult Schedule(int id)
        {
            return View(Mapper.Map<Diet, DietViewModel>(_dietRepository.Get(id)));
        }

        public ActionResult SearchResult(string searchString)
        {
            var result = Mapper.Map<IEnumerable<Diet>, IEnumerable<DietViewModel>>(_dietRepository.Query(diet => diet.Name.ToLower().Contains(searchString.ToLower())));
            return PartialView("_DietSearchresult", result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["Categories"] = _categoryRepository.GetAll().OrderBy(category => category.Name);
            return View(new DietViewModel());
        }

        [HttpPost]
        public ActionResult Create(DietViewModel viewModel, HttpPostedFileBase file)
        {
            ViewData["Categories"] = _categoryRepository.GetAll().OrderBy(category => category.Name);
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    viewModel.ImgUrl = string.Format("/Uploads/{0}", file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Uploads"), Path.GetFileName(file.FileName));
                    file.SaveAs(filePath);
                }
                viewModel.DateAdded = DateTime.Now;
                var diet = _dietRepository.Create(Mapper.Map<DietViewModel, Diet>(viewModel));
                return RedirectToAction("AddMeals", new {id = diet.Id});
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddMeals(int id)
        {
            ViewData["Days"] = new List<Day> { new Day(0), new Day(1), new Day(2), new Day(3), new Day(4), new Day(5), new Day(6) };
            ViewData["Time"] = TimeHelper.GetTimesForDay();
            ViewData["QuantityTypes"] = _quantityTypeRepository.GetAll().OrderBy(qt => qt.Name).ToList();
            return View(Mapper.Map<Diet, DietViewModel>(_dietRepository.Get(id)));
        }

        public void AddIngredientToDiet(int dietId, int ingredientId, double quantity, int quantityId, string day, int time)
        {
            _dietIngredientRepository.Add(new DietIngredient { DietId = dietId, IngredientId = ingredientId, Quantity = quantity, QuantityTypeId = quantityId, Day =  day, Time = time});
        }

        public void DeleteIngredientFromDiet(int dietId, int ingredientId)
        {
            _dietIngredientRepository.RemoveIngredientFromDiet(dietId, ingredientId);
        }

        public ActionResult GetMealsForDiet(int id)
        {
            var result = Mapper.Map<IEnumerable<DietMeal>, IEnumerable<DietMealViewModel>>(_dietRepository.Get(id).DietMeals);
            return PartialView("_MealsForDiet", result);
        }

        public ActionResult GetIngredientsForDiet(int id)
        {
            var result = Mapper.Map<IEnumerable<DietIngredient>, IEnumerable<DietIngredientViewModel>>(_dietRepository.Get(id).DietIngredients);
            return PartialView("_IngredientsForDiet", result);
        }

        public void AddMealToDiet(int dietId, int mealId, string day, int time)
        {
            _dietMealRepository.Add(new DietMeal { DietId  = dietId, MealId = mealId, Day = day, Time = time });
        }

        [HttpPost]
        public ActionResult AddMeals(DietViewModel viewModel)
        {
            return View();
        }

        public ActionResult AddNewComment(int dietId, string message, string name, string webUrl, string email, int? commentId, int? userId)
        {
            var comment = new Comment { DateAdded = DateTime.Now, Diet = _dietRepository.Get(dietId), Text = message};
            if (userId.HasValue && userId.Value >0)
            {
                comment.User = _userRepository.Get(userId.Value);
            }
            else
            {
                comment.Username = name;
                comment.Email = email;
                comment.WebSite = webUrl;
            }
            if (commentId.HasValue && commentId.Value > 0)
            {
                comment.CommentId = commentId.Value;
            }
            _commentRepository.Add(comment);
            var comments = _commentRepository.GetCommentsForDiet(dietId);
            return PartialView("_Comments", Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(comments));
        }

        public void SetDietAsDefault(int dietId)
        {
            var user = SessionFacade.User;
            if(user != null)
            {
                _userDietRepository.Add(new UserDiet{ Active = true, DietId = dietId, UserId = user.Id});
            }
        }

        public void RemoveIngredientFromDiet(int dietId, int ingredientId)
        {
            _dietIngredientRepository.Remove(
                _dietIngredientRepository.Find(di => di.DietId == dietId && di.IngredientId == ingredientId));
        }

        public void RemoveMealFromDiet(int dietId, int mealId)
        {
            _dietMealRepository.Remove(
                _dietMealRepository.Find(di => di.DietId == dietId && di.MealId == mealId));
        }
    }

    public class Time
    {
        public int Minutes { get; set; }
        public string TimeOfDay { get { return DateTime.Today.AddMinutes(Minutes).ToShortTimeString(); } }

        public Time(int minutes)
        {
            Minutes = minutes;
        }
    }

    public class Day
    {
        public int Daynumber { get; set; }
        public string DayOfWeek { get { return Enum.GetName(typeof (ScheduleHelper.Days), Daynumber % 7); } }

        public Day(int daynumber)
        {
            Daynumber = daynumber;
        }
    }
}
