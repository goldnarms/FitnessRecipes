using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers.Api
{
    public class RecipeController : ApiController
    {
        private readonly RecipeRepository _repository;

        public RecipeController()
        {
            _repository = ObjectFactory.GetRepositoryInstance<Recipe, RecipeRepository>(new DbContextFactory().GetFitnessRecipeEntities());
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _repository.GetAll().OrderBy(recipe => recipe.Notes);
        }

        public Recipe GetRecipe(int id)
        {
            return _repository.Get(id);
        }

        public HttpResponseMessage PutRecipe(int id, Recipe recipe)
        {
            if (ModelState.IsValid && id == recipe.MealId)
            {
                try
                {
                    _repository.Update(id, recipe);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, recipe);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostRecipe(RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipe = Mapper.Map(recipeViewModel, new Recipe());
                _repository.Add(recipe);

                var response = Request.CreateResponse(HttpStatusCode.Created, recipe);
                response.Headers.Location = new Uri(Url.Link("~/recipe/", new { id = recipe.MealId }));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage DeleteRecipe(int id)
        {
            var recipe = _repository.Get(id);
            if (recipe == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Remove(recipe);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, recipe);
        }
    }
}
