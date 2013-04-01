using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    public class AuthorController : ApiController
    {
        private readonly AuthorRepository _repository;
        private readonly IRepositoryManager<Author> _repositoryManager;

        public AuthorController()
        {
            _repository = ObjectFactory.GetRepositoryInstance<Author, AuthorRepository>(new DbContextFactory().GetFitnessRecipeEntities());
            _repositoryManager = new AuthorRepositoryManager();
        }

        public List<AuthorViewModel> GetAuthors()
        {
            return Mapper.Map<IEnumerable<Author>, List<AuthorViewModel>>(_repository.GetAll());
        }

        public Author GetAuthor(int? id)
        {
            if (id != null) return _repository.Get(id.Value);
            return null;
        }

        public HttpResponseMessage PutAuthor(int id, AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid && id == authorViewModel.UserId)
            {
                try
                {
                    var author = new Author();
                    Mapper.Map(authorViewModel, author);
                    _repository.Update(id, author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, authorViewModel);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostAuthor(AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var author = _repositoryManager.Create(Mapper.Map<AuthorViewModel, Author>(authorViewModel), authorViewModel.Description);
                var response = Request.CreateResponse(HttpStatusCode.Created, author);
                response.Headers.Location = new Uri(Url.Link("~/api/Author/", new { id = author.UserId }));
                return response;
            }
            
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage DeleteAuthor(int id)
        {
            var author = _repository.Get(id);
            if (author == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Remove(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, author);
        }
    }
}