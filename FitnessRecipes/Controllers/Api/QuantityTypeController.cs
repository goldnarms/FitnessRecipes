using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Repositories;

namespace FitnessRecipes.Controllers.Api
{
    public class QuantityTypeController : ApiController
    {
        private readonly QuantityTypeRepository _repository;

        public QuantityTypeController()
        {
            _repository = ObjectFactory.GetRepositoryInstance<QuantityType, QuantityTypeRepository>(new DbContextFactory().GetFitnessRecipeEntities());
        }

        public IEnumerable<QuantityType> GetQuantityTypes()
        {
            return _repository.GetAll().OrderBy(quantityType => quantityType.Name);
        }

        public QuantityType GetQuantityType(int id)
        {
            return _repository.Get(id);
        }

        public HttpResponseMessage PutQuantityType(int id, QuantityType quantityType)
        {
            if (ModelState.IsValid && id == quantityType.Id)
            {
                try
                {
                    _repository.Update(id, quantityType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, quantityType);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostQuantityType(QuantityType quantityType)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(quantityType);

                var response = Request.CreateResponse(HttpStatusCode.Created, quantityType);
                response.Headers.Location = new Uri(Url.Link("~/api/quantityType/", new { id = quantityType.Id }));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage DeleteQuantityType(int id)
        {
            var quantityType = _repository.Get(id);
            if (quantityType == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Remove(quantityType);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
