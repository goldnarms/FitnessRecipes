using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers.Api
{
    public class FitnessRecipesController : ApiController
    {
        private IRecipeRepositoryManager _repositoryManager;

        public FitnessRecipesController()
        {
            _repositoryManager = new FitnessRecipeRepositoryManager();
        }

        public HttpResponseMessage PostFitnessRecipe(FitnessRecipesViewModel recipe)
        {
            if (ModelState.IsValid)
            {
                _repositoryManager.Create(Mapper.Map<FitnessRecipesViewModel, Recipe>(recipe), recipe.Note, recipe.Foods);

                var response = Request.CreateResponse(HttpStatusCode.Created, recipe);
                //response.Headers.Location = new Uri(Url.Link("Recipe", new { id = recipe.ID }));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
