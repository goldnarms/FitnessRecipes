using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeRepository _recipeRepository;

        public RecipeController(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public ActionResult Index()
        {
            var oppskrifter = Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(_recipeRepository.GetAll()).ToList();
            const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var alfabetDic = alfabet.ToDictionary(t => t, t => oppskrifter.Where(oppskrift => oppskrift.Meal.Name.ToUpper()[0] == t).ToList());
            return View(alfabetDic);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new RecipeViewModel());
        }

        [HttpPost]
        public ActionResult Create(RecipeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _recipeRepository.Create(Mapper.Map<RecipeViewModel, Recipe>(viewModel));

            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Recipe(int id)
        {
            return View(Mapper.Map<Recipe, RecipeViewModel>(_recipeRepository.Get(id)));
        }

        public ActionResult SearchResult(string searchString)
        {
            var result = Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(_recipeRepository.Query(recipe => recipe.Meal.Name.ToLower().Contains(searchString.ToLower())));
            return PartialView("_RecipeSearchresult", result);
        }
    }
}
