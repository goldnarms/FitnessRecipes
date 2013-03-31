using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class BaseController : Controller
    {
        private readonly RecipeRepository _recipeRepository;

        public BaseController()
        {
            var fitnessEntities = new DbContextFactory().GetFitnessRecipeEntities();
            _recipeRepository = new RecipeRepository(fitnessEntities);
        }

        [ChildActionOnly]
        public ActionResult LatestRecipes()
        {
            return PartialView("_LatestRecipes", Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(_recipeRepository.GetAll().OrderBy(recipe => recipe.User)));
        }
        [ChildActionOnly]
        public ActionResult MatchingRecipes()
        {
            return PartialView("_RecipeList", Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(_recipeRepository.GetAll().OrderBy(recipe => recipe.User)));
        }
    }
}
