using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Repositories;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Controllers
{
    public class IngredientController : BaseController
    {
        private readonly IngredientRepository _ingredientRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IQuantityTypeRepository _quantityTypeRepository;
        private readonly IMealRepository _mealRepository;

        public IngredientController(IngredientRepository ingredientRepository, IRepository<Brand> brandRepository, IQuantityTypeRepository quantityTypeRepository, IMealRepository mealRepository)
        {
            _ingredientRepository = ingredientRepository;
            _brandRepository = brandRepository;
            _quantityTypeRepository = quantityTypeRepository;
            _mealRepository = mealRepository;
        }

        public ActionResult Index()
        {
            var ingredients = Mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientViewModel>>(_ingredientRepository.GetAll());
            const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var alfabetDic = alfabet.ToDictionary(t => t, t => ingredients.Where(ingredient => ingredient.Name.ToUpper()[0] == t).ToList());
            return View(alfabetDic);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _ingredientRepository.Get(id);
            var viewModel = Mapper.Map<Ingredient, IngredientViewModel>(model);
            viewModel.Meals = Mapper.Map<IEnumerable<Meal>, IEnumerable<MealViewModel>>(_mealRepository.GetAll().Where(meal => meal.MealIngredients.Any(mi => mi.IngredientId == id)));
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var brands = _brandRepository.GetAll().OrderBy(brand => brand.Name).ToList();
            brands.Insert(0, new Brand { Id = 0, Name = "Har ingen merke" });
            ViewData["Brands"] = brands;
            var viewmodel = new IngredientViewModel
                                {
                                    Quantities =
                                        Mapper.Map<IEnumerable<QuantityType>, IEnumerable<QuantityTypeViewModel>>(
                                            _quantityTypeRepository.GetAll())
                                };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(IngredientViewModel viewModel)
        {
            var brands = _brandRepository.GetAll().OrderBy(brand => brand.Name).ToList();
            brands.Insert(0, new Brand { Id = 0, Name = "Har ingen merke" });
            ViewData["Brands"] = brands;
            try
            {
                viewModel.DateAdded = DateTime.Now;
                _ingredientRepository.Create(Mapper.Map<IngredientViewModel, Ingredient>(viewModel));
                return RedirectToAction("Create");
            }
            catch
            {
                return View(viewModel);
            }
        }
        public ActionResult SearchResult(string searchString)
        {
            var result = Mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientViewModel>>(_ingredientRepository.Query(ingredient => !ingredient.IsDeleted && ingredient.Name.ToLower().Contains(searchString.ToLower())).OrderBy(i => i.Name));
            return PartialView("_AddIngredients", result);
        }

        public ActionResult Categories(int id)
        {
            var result = Mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientViewModel>>(_ingredientRepository.Query(ingredient => !ingredient.IsDeleted && ingredient.CategoryId == id).OrderBy(i => i.Name));
            return PartialView("_AddIngredients", result);
        }

        public ActionResult GetBrands()
        {
            var brands = _brandRepository.GetAll().OrderBy(brand => brand.Name).ToList();
            brands.Insert(0, new Brand { Id = 0, Name = "Har ingen merke" });
            return Json(Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brands));
        }

        public bool CreateBrand(BrandViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _brandRepository.Create(Mapper.Map<BrandViewModel, Brand>(viewModel));
                }
                catch (Exception exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
