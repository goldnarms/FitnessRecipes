using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Services;
using FitnessRecipes.Helpers;
using FitnessRecipes.Resources.Common;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealRepository _mealRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IQuantityTypeRepository _quantityTypeRepository;
        private readonly IIngredientCategoryRepository _ingredientCategoryRepository;
        private readonly IMealIngredientRepository _mealIngredientRepository;
        private readonly IMealCategoryRepository _categoryRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IIngredientQuantityRepository _ingredientQuantityRepository;

        public MealController(IMealRepository mealRepository, IIngredientRepository ingredientRepository, IQuantityTypeRepository quantityTypeRepository, IIngredientCategoryRepository ingredientCategoryRepository, IMealIngredientRepository mealIngredientRepository, IMealCategoryRepository categoryRepository, IRecipeRepository recipeRepository, IUserRepository userRepository, IAuthorRepository authorRepository, IIngredientQuantityRepository ingredientQuantityRepository)
        {
            _mealRepository = mealRepository;
            _ingredientRepository = ingredientRepository;
            _quantityTypeRepository = quantityTypeRepository;
            _ingredientCategoryRepository = ingredientCategoryRepository;
            _mealIngredientRepository = mealIngredientRepository;
            _categoryRepository = categoryRepository;
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _authorRepository = authorRepository;
            _ingredientQuantityRepository = ingredientQuantityRepository;
        }

        public ActionResult Index()
        {
            var oppskrifter = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(_mealRepository.GetAll()).ToList();
            const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var alfabetDic = alfabet.ToDictionary(t => t, t => oppskrifter.Where(oppskrift => oppskrift.Name.ToUpper()[0] == t).ToList());
            return View(alfabetDic);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(int? id)
        {
            ViewData["Categories"] = _categoryRepository.GetAll().OrderBy(category => category.Name);
            return View(id.HasValue ? Mapper.Map<Meal, MealViewModel>(_mealRepository.Get(id.Value)) : new MealViewModel());
        }

        [HttpPost]
        public ActionResult Create(MealViewModel viewModel)
        {
            ViewData["Categories"] = _categoryRepository.GetAll().OrderBy(category => category.Name);
            if (ModelState.IsValid)
            {
                var user = SessionFacade.User;
                HttpPostedFileBase file = viewModel.File;
                if (file != null && file.ContentLength > 0)
                {
                    viewModel.ImgUrl = string.Format("/Uploads/{0}", file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Uploads"), Path.GetFileName(file.FileName));
                    file.SaveAs(filePath);
                }
                var meal = Mapper.Map<MealViewModel, Meal>(viewModel);
                meal.DateAdded = DateTime.Today;
                if(user != null)
                    meal.UserId = user.Id;
                meal.Name = viewModel.Name;
                if (meal.Id > 0)
                    _mealRepository.Update(meal);
                else
                    _mealRepository.Add(meal);
                return RedirectToAction("AddIngredients", new { mealId = meal.Id });
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddIngredients(int mealId)
        {
            var meal = _mealRepository.Get(mealId);
            ViewData["QuantityTypes"] = _quantityTypeRepository.GetAll().OrderBy(qt => qt.Name).ToList();
            return View(Mapper.Map<Meal, MealViewModel>(meal));
        }

        [HttpGet]
        public ActionResult Meal(int id)
        {
            var meal = _mealRepository.Get(id);
            var mealViewModel = Mapper.Map<Meal, MealViewModel>(meal);
            var mealCalculator = new MealCalculator(meal, _ingredientQuantityRepository);
            mealViewModel.Kcal = mealCalculator.CalculateTotalKcal();
            mealViewModel.Protein = mealCalculator.CalculateTotalProtein();
            mealViewModel.Fat = mealCalculator.CalculateTotalFat();
            mealViewModel.Carb = mealCalculator.CalculateTotalCarb();
            return View(mealViewModel);
        }

        public ActionResult SearchResult(string searchString)
        {
            var result = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(_mealRepository.Query(meal => meal.Name.ToLower().Contains(searchString.ToLower())));
            return PartialView("_MealSearchResult", result);
        }

        public ActionResult SearchResultForDiet(string searchString)
        {
            var result = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(_mealRepository.Query(meal => meal.Name.ToLower().Contains(searchString.ToLower())));
            return PartialView("_AddMeals", result);
        }

        public ActionResult MealIngredients(int id)
        {
            var result = Mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientViewModel>>(_ingredientRepository.Filter(ingredient => ingredient.MealIngredients.Any(meal => meal.MealId == id)));
            return PartialView("_AddIngredients", result);
        }

        public ActionResult GetIngredientCategories()
        {
            var result = Mapper.Map<IEnumerable<IngredientCategory>, IEnumerable<IngredientCategoryViewModel>>(_ingredientCategoryRepository.GetAll().OrderBy(c => c.Name));
            return PartialView("_IngredientCategories", result);
        }

        public ActionResult GetMealCategories()
        {
            var result = Mapper.Map<IEnumerable<MealCategory>, IEnumerable<MealCategoryViewModel>>(_categoryRepository.GetAll().OrderBy(c => c.Name));
            return PartialView("_MealCategories", result);
        }

        public ActionResult Categories(int id)
        {
            var result = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(_mealRepository.Query(meal => !meal.IsDeleted && meal.CategoryId == id).OrderBy(i => i.Name));
            return PartialView("_AddMeals", result);
        }

        public ActionResult GetIngredientsForMeal(int id)
        {
            var result = Mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientViewModel>>(_ingredientRepository.Filter(ingredient => ingredient.MealIngredients.Any(meal => meal.MealId == id)));
            return PartialView("_IngredientsForMeal", result);
        }

        public void AddIngredientToMeal(int mealId, int ingredientId, double quantity, int quantityId, bool optional)
        {
            _mealIngredientRepository.Add(new MealIngredient { MealId = mealId, IngredientId = ingredientId, Quantity = quantity, QuantityTypeId = quantityId, Optional = optional });
        }

        public void AddToFavorite(int mealId)
        {
            var user = SessionFacade.User;
            if (user != null)
            {
                var userDb = _userRepository.Get(user.Id);
                var meal = _mealRepository.Get(mealId);
                if (meal != null)
                {
                    userDb.MealFavorites.Add(_mealRepository.Get(mealId));
                    _userRepository.Update(userDb.Id, userDb);
                }
            }
        }

        public void DeleteMeal(int id)
        {
            var meal = _mealRepository.Get(id);
            meal.IsDeleted = true;
            _mealRepository.Update(meal);
        }

        [HttpGet]
        public ActionResult AddRecipe(int id)
        {
            var meal = _mealRepository.Get(id);
            if (meal.Recipe == null)
            {
                meal.Recipe = new Recipe();
            }
            ViewData[CommonValues.Authors] = _authorRepository.GetAll().OrderBy(author => author.User.Name);
            return View(Mapper.Map<Meal, MealViewModel>(meal));
        }

        [HttpPost]
        public ActionResult AddRecipe(MealViewModel viewModel)
        {
            var user = SessionFacade.User;
            ViewData[CommonValues.Authors] = _authorRepository.GetAll().OrderBy(author => author.User.Name);
            if (ModelState.IsValid)
            {
                var recipe = Mapper.Map<RecipeViewModel, Recipe>(viewModel.Recipe);
                if (_recipeRepository.Contains(r => r.MealId == viewModel.Id))
                {
                    _recipeRepository.Update(recipe);
                }
                else
                {
                    recipe.DateAdded = DateTime.Now;
                    if (recipe.User == null && user != null)
                        recipe.UserId = user.Id;
                    recipe.MealId = viewModel.Id;
                    _recipeRepository.Create(recipe);
                }
                return View("Meal", viewModel);
            }
            return View(viewModel);
        }

        public ActionResult SetupMealSlider()
        {
            var meals = _mealRepository.GetAll().OrderByDescending(meal => meal.DateAdded).Take(5);
            return PartialView("_MealSlider", Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(meals));
        }

        public void AddToFavorites(int id)
        {

        }
    }
}
