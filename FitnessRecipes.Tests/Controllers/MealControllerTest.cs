using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FitnessRecipes.Controllers;
using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Repositories;
using FitnessRecipes.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.Controllers
{
    [TestClass]
    public class MealControllerTest
    {
        private MealController _controller;
        private IMealRepository _mealRepository;
        private IIngredientRepository _ingredientRepository;
        private IQuantityTypeRepository _quantityTypeRepository;
        private IIngredientCategoryRepository _ingredientCategoryRepository;
        private IMealIngredientRepository _mealIngredientRepository;
        private IMealCategoryRepository _mealCategoryRepository;
        private IRecipeRepository _recipeRespository;
        private IUserRepository _userRepository;
        private IAuthorRepository _authorRepository;
        private IIngredientQuantityRepository _ingredientQuantityRepository;
        private Meal _meal;

        public MealControllerTest()
        {
            MapperConfig.ConfigureMapper();
            _mealRepository = new FakeMealRepository();
            _ingredientRepository = new FakeIngredientRepository();
            _quantityTypeRepository = new FakeQuantityTypeRepository();
            _ingredientCategoryRepository = new FakeIngredientCategoryRepository();
            _mealIngredientRepository = new FakeMealIngredientRepository();
            _mealCategoryRepository = new FakeMealCategoryRepository();
            _recipeRespository = new FakeRecipeRepository();
            _userRepository =  new FakeUserRepository();
            _authorRepository = new FakeAuthorRepository();
            _ingredientQuantityRepository = new FakeIngredientQuantityRepository();
            _controller = new MealController(_mealRepository, _ingredientRepository, _quantityTypeRepository, _ingredientCategoryRepository, _mealIngredientRepository, _mealCategoryRepository, _recipeRespository, _userRepository, _authorRepository, _ingredientQuantityRepository);
        }

        [TestInitialize]
        public void TestSetup()
        {
            _meal = ModelCreator.CreateOatMeal();
        }

        [TestMethod]
        public void ShouldGetAListOfMeal()
        {
            var result = _controller.Index() as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<Dictionary<char, List<MealViewModel>>>();
        }

        [TestMethod]
        public void ShouldGetADetailView()
        {
            var mealId = _mealRepository.Create(_meal).Id;
            var result = _controller.Meal(mealId) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<MealViewModel>();
        }

        [TestMethod]
        public void ShouldGetTotalKcalForMeal()
        {
            var mealId = _mealRepository.Create(_meal).Id;
            var result = _controller.Meal(mealId) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<MealViewModel>();
            var mealViewModel = result.Model as MealViewModel;
            mealViewModel.Kcal.ShouldEqual(370.4);
        }

        [TestMethod]
        public void ShouldGetTotalProteinForMeal()
        {
            var mealId = _mealRepository.Create(_meal).Id;
            var result = _controller.Meal(mealId) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<MealViewModel>();
            var mealViewModel = result.Model as MealViewModel;
            mealViewModel.Protein.ShouldEqual(44.94);
        }

        [TestMethod]
        public void ShouldGetTotalFatForMeal()
        {
            var mealId = _mealRepository.Create(_meal).Id;
            var result = _controller.Meal(mealId) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<MealViewModel>();
            var mealViewModel = result.Model as MealViewModel;
            mealViewModel.Fat.ShouldEqual(5.59);
        }

        [TestMethod]
        public void ShouldGetTotalCarbForMeal()
        {
            var mealId = _mealRepository.Create(_meal).Id;
            var result = _controller.Meal(mealId) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<MealViewModel>();
            var mealViewModel = result.Model as MealViewModel;
            mealViewModel.Carb.ShouldEqual(35.828);
        }
        //[TestMethod]
        //public void ShouldGetTotalKcalForMeal()
        //{
        //    var ingredient1 = ModelCreator.CreateIngredient();
        //    var ingredient2 = ModelCreator.CreateIngredient();
        //    ingredient2.Carb = 33;
        //    ingredient2.Fat = 45;
        //    ingredient2.Protein = 55;
        //    ingredient2.Kcal = 450;

        //    var mealId = _mealRepository.Create(_meal).Id;
        //    var result = _controller.Meal(mealId) as ViewResult;
        //    result.ShouldNotBeNull();
        //    result.Model.ShouldBeType<MealViewModel>();
        //}
    }
}
