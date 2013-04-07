﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;
using LoginRadiusSDKv2;

namespace FitnessRecipes.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IDietRepository _dietRepository;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository, IDietRepository dietRepository, IAuthorRepository authorRepository)
        {
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
            _dietRepository = dietRepository;
            _authorRepository = authorRepository;
        }

        //public HomeController()
        //{
        //    var fitnessRecipeEntites = new DbContextFactory().GetFitnessRecipeEntities();
        //    _ingredientRepository = new IngredientRepository(fitnessRecipeEntites);
        //    _recipeRepository = new RecipeRepository(fitnessRecipeEntites);
        //    _dietRepository = new DietRepository(fitnessRecipeEntites);
        //    _authorRepository = new AuthorRepository(fitnessRecipeEntites);
        //}

        public ActionResult Index()
        {
            var login = new LoginRadius("1a187df5-ff86-48d7-88d7-151e79847f08");

            var viewModel = new FrontPageViewModel();
            viewModel.Recipes = Mapper.Map<IEnumerable<Recipe>, List<RecipeViewModel>>(_recipeRepository.GetAll().OrderByDescending(r => r.DateAdded).Take(5));
            viewModel.Diets = Mapper.Map<IEnumerable<Diet>, List<DietViewModel>>(_dietRepository.GetAll().OrderByDescending(diet => diet.Id).Take(5));
            viewModel.Authors = Mapper.Map<List<Author>, List<AuthorViewModel>>(_authorRepository.GetAll().Take(5).OrderByDescending(author => author.UserId).ToList());
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddIngredient(int ingredientId)
        {
            var ingredientsHave = ((List<IngredientViewModel>)ViewData["IngredientsHave"]);
            ingredientsHave.Add(Mapper.Map(_ingredientRepository.Get(ingredientId), new IngredientViewModel()));
            ViewData["IngredientsHave"] = ingredientsHave;
            return PartialView("_IngredientsHave", ingredientsHave);
        }

        [HttpDelete]
        public ActionResult RemoveIngredient(int ingredientId)
        {
            var ingredientsHave = ((List<IngredientViewModel>)ViewData["IngredientsHave"]);
            ingredientsHave.Remove(Mapper.Map(_ingredientRepository.Get(ingredientId), new IngredientViewModel()));
            ViewData["IngredientsHave"] = ingredientsHave;
            return PartialView("_IngredientsHave", ingredientsHave);
        }

        public ActionResult Author()
        {
            return View();
        }

        public ActionResult Language()
        {
            return View();
        }

        public ActionResult FitnessRecipes()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
