using System;
using System.Collections.Generic;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.DAL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.UnitTests
{
    [TestClass]
    public class MealCalculatorTest
    {
        private IDietRepository _dietRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;
        private IDietCategoryRepository _dietCategoryRepository;
        private IDietMealRepository _dietMealRepository;
        private IDietIngredientRepository _dietIngredientRepository;
        private IQuantityTypeRepository _quantityTypeRepository;
        private IUserDietRepository _userDietRepository;
        private IIngredientRepository _ingredientRepository;
        private IMealRepository _mealRepository;
        private IIngredientQuantityRepository _ingredientQuantityRepository;

        public MealCalculatorTest()
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
            _mealRepository = new FakeMealRepository();
            _ingredientQuantityRepository = new FakeIngredientQuantityRepository();
        }

        [TestMethod]
        public void ShouldCalculateKcalsForMeal()
        {
            var ingredient1 = ModelCreator.CreateIngredient();
            var ingredient2 = ModelCreator.CreateIngredient();
            ingredient2.Kcal = 200;
            var meal = ModelCreator.CreateMeal();
            _mealRepository.Create(meal);
            var mealIngredients1 = ModelCreator.CreateMealIngredients(meal, ingredient1, ModelCreator.CreateQuantityType(12));
            var mealIngredients2 = ModelCreator.CreateMealIngredients(meal, ingredient2, ModelCreator.CreateQuantityType(12));
            meal.MealIngredients = new List<MealIngredient> { mealIngredients1, mealIngredients2 };
            var mealCalculator = new MealCalculator(meal, _ingredientQuantityRepository);
            mealCalculator.CalculateTotalKcal().ShouldEqual(960);
        }
    }
}
