using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using FitnessRecipes.Controllers;
using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.Controllers
{
    /// <summary>
    /// Summary description for DietControllerTest
    /// </summary>
    [TestClass]
    public class DietControllerTest
    {
        private DietController _controller;
        private IDietRepository _dietRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;
        private IDietCategoryRepository _dietCategoryRepository;
        private IDietMealRepository _dietMealRepository;
        private IDietIngredientRepository _dietIngredientRepository;
        private IQuantityTypeRepository _quantityTypeRepository;
        private IUserDietRepository _userDietRepository;
        private IIngredientRepository _ingredientRepository;
        private Diet _diet;

        public DietControllerTest()
        {
            MapperConfig.ConfigureMapper();
            _dietRepository = new FakeDietRepository();
            _commentRepository = new FakeCommentRepository();
            _userRepository = new FakeUserRepository();
            _dietCategoryRepository = new FakeDietCategoryRepository();
            _dietMealRepository = new FakeDietMealRepository();
            _dietIngredientRepository = new FakeDietIngredientRepository();
            _quantityTypeRepository = new FakeQuantityTypeRepository();
            _userDietRepository = new FakeUserDietRepository();
            _ingredientRepository = new FakeIngredientRepository();
            _controller = new DietController(_dietRepository, _commentRepository, _userRepository, _dietCategoryRepository, _dietMealRepository, _dietIngredientRepository, _quantityTypeRepository, _userDietRepository);
        }

        [TestInitialize]
        public void TestSetup()
        {
            _diet = ModelCreator.CreateDiet();
            var ingredient1 = ModelCreator.CreateIngredient();
            var ingredient2 = ModelCreator.CreateIngredient();
            ingredient2.Kcal = 200;
            ingredient2.Fat = 24;
            ingredient2.Protein = 44;
            var meal = ModelCreator.CreateMeal();
            var mealIngredients1 = ModelCreator.CreateMealIngredients(meal, ingredient1, ModelCreator.CreateQuantityType(1));
            var mealIngredients2 = ModelCreator.CreateMealIngredients(meal, ingredient2, ModelCreator.CreateQuantityType(2));
            meal.MealIngredients = new List<MealIngredient> { mealIngredients1, mealIngredients2 };
            var dietMeal = ModelCreator.CreateDietMeal(_diet, meal);
            var dietIngredient = ModelCreator.CreateDietIngredient(_diet, ingredient1);
            _diet.DietIngredients = new List<DietIngredient> { dietIngredient };
            _diet.DietMeals = new List<DietMeal> { dietMeal };
            var dietId = _dietRepository.Create(_diet).Id;
            var ingredientId = _ingredientRepository.Create(ingredient1).Id;
            _dietMealRepository.Create(dietMeal);
            _dietIngredientRepository.Create(dietIngredient);
            
        }

        [TestMethod]
        public void ShouldGetAOverviewOfAllDiets()
        {
            var result = _controller.Index();
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void ShouldGetADetailView()
        {
            var result = _controller.Details(_diet.Id) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<DietViewModel>();
            var viewModel = result.Model as DietViewModel;
            viewModel.Description.ShouldEqual(_diet.Description);
        }

        [TestMethod]
        public void ShouldGetAverageKcalForDiet()
        {
            var result = _controller.Details(_diet.Id) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<DietViewModel>();
            var dietViewModel = result.Model as DietViewModel;
            dietViewModel.Kcal.HasValue.ShouldBeTrue();
            dietViewModel.Kcal.Value.ShouldEqual(1200);
        }

        [TestMethod]
        public void ShouldGetFatPercentageForDiet()
        {
            var result = _controller.Details(_diet.Id) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<DietViewModel>();
            var dietViewModel = result.Model as DietViewModel;
            dietViewModel.Fat.HasValue.ShouldBeTrue();
            dietViewModel.Fat.Value.ToString("N2").ShouldEqual("25,68");
        }
        
        [TestMethod]
        public void ShouldGetCarbPercentageForDiet()
        {
            var result = _controller.Details(_diet.Id) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<DietViewModel>();
            var dietViewModel = result.Model as DietViewModel;
            dietViewModel.Carb.HasValue.ShouldBeTrue();
            dietViewModel.Carb.Value.ToString("N2").ShouldEqual("15,56");
        }

        [TestMethod]
        public void ShouldGetProteinPercentageForDiet()
        {
            var result = _controller.Details(_diet.Id) as ViewResult;
            result.ShouldNotBeNull();
            result.Model.ShouldBeType<DietViewModel>();
            var dietViewModel = result.Model as DietViewModel;
            dietViewModel.Protein.HasValue.ShouldBeTrue();
            dietViewModel.Protein.Value.ToString("N2").ShouldEqual("58,75");
        }
    }
}
