using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Helpers;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class QuantityTypeController : Controller
    {
        private IRepositoryManager<QuantityType> _repositoryManager;
        private readonly IQuantityTypeRepository _repository;

        public QuantityTypeController(IRepositoryManager<QuantityType> repositoryManager, IQuantityTypeRepository repository)
        {
            _repositoryManager = repositoryManager;
            _repository = repository;
        }

        public ActionResult Index()
        {
            var quantityTypes = Mapper.Map<IEnumerable<QuantityType>, IEnumerable<QuantityTypeViewModel>>(_repository.GetAll());
            const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var quantityTypeViewModels = quantityTypes as List<QuantityTypeViewModel> ?? quantityTypes.ToList();
            var alfabetDic = quantityTypeViewModels.Any()
                                 ? alfabet.ToDictionary(t => t,
                                                        t =>
                                                        quantityTypeViewModels.Where(
                                                            quantityType => quantityType.Name != null && quantityType.Name.ToUpper()[0] == t).ToList())
                                 : null;
            return View(alfabetDic);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuantityTypeViewModel());
        }

        [HttpPost]
        [AcceptParameter(Name = "button", Value = "create")]
        public ActionResult Create(QuantityTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var quantityType = _repositoryManager.Create(
                    Mapper.Map<QuantityTypeViewModel, QuantityType>(viewModel), viewModel.Name);
                if (quantityType != null)
                {
                    //_messagePoster.SendMessage("Suksess", true);
                    ModelState.Clear();
                    TempData["message"] = "success";
                }
                else
                {
                    TempData["message"] = "error";
                }
            }
            else
            {
                TempData["message"] = "error";
            }

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [AcceptParameter(Name = "button", Value = "cancel")]
        public ActionResult Cancel()
        {
            ModelState.Clear();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var quantityType = _repository.Get(id);
            if (quantityType == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _repository.Remove(quantityType);
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }
    }
}
