using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Repositories;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private readonly Repository<MealCategory> _repository;
        private IRepositoryManager<MealCategory> _repositoryManager;

        public CategoryController()
        {
            _repository = ObjectFactory.GetRepositoryInstance<MealCategory, CategoryRepository>(new DbContextFactory().GetFitnessRecipeEntities());
            _repositoryManager = new CategoryRepositoryManager();
        }

        public IEnumerable<MealCategoryViewModel> GetCategories()
        {
            //return _repository.GetAll().OrderBy(category => category.Text.TextValue);
            return Mapper.Map<IEnumerable<MealCategory>, IEnumerable<MealCategoryViewModel>>(_repository.GetAll().OrderBy(category => category.Name));
        }

        public MealCategory GetCategory(int id)
        {
            return _repository.Get(id);
        }

        public HttpResponseMessage PutCategory(int id, MealCategory category)
        {
            if (ModelState.IsValid && id == category.Id)
            {
                try
                {
                    _repository.Update(id, category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, category);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostCategory(MealCategoryViewModel mealCategoryViewModel)
        {
            var category = _repositoryManager.Create(Mapper.Map<MealCategoryViewModel, MealCategory>(mealCategoryViewModel), mealCategoryViewModel.Name);
            if (ModelState.IsValid)
            {
                _repository.Add(category);

                var response = Request.CreateResponse(HttpStatusCode.Created, category);
                response.Headers.Location = new Uri(Url.Link("~/api/category/", new { id = category.Id }));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage DeleteCategory(int id)
        {
            var category = _repository.Get(id);
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Remove(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, category);
        }
    }
}
