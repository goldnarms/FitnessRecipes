using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Repositories;
using FitnessRecipes.Models;

namespace FitnessRecipes.Controllers.Api
{
    public class IngredientController : ApiController
    {
        private readonly IngredientRepository _repository;

        public IngredientController()
        {
            _repository = ObjectFactory.GetRepositoryInstance<Ingredient, IngredientRepository>(new DbContextFactory().GetFitnessRecipeEntities());
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _repository.GetAll().OrderBy(ingredient => ingredient.Name);
        }

        public Ingredient GetIngredient(int? id)
        {
            return id.HasValue ? _repository.Get(id.Value) : null;
        }

        public HttpResponseMessage PutIngredient(int id, Ingredient ingredient)
        {
            if (ModelState.IsValid && id == ingredient.Id)
            {
                try
                {
                    _repository.Update(id, ingredient);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, ingredient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostIngredient(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(ingredient);

                var response = Request.CreateResponse(HttpStatusCode.Created, ingredient);
                response.Headers.Location = new Uri(Url.Link("~/api/ingredient/", new { id = ingredient.Id }));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage DeleteIngredient(int id)
        {
            var ingredient = _repository.Get(id);
            if (ingredient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Remove(ingredient);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ingredient);
        }
    }
}
