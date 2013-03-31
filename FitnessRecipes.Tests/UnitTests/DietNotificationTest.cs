using System;
using System.Collections;
using System.Collections.Generic;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Helpers;
using FitnessRecipes.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.UnitTests
{
    [TestClass]
    public class DietNotificationTest
    {
        [TestMethod]
        public void ShouldGetMealsForADay()
        {
            var meals = new List<DietMealViewModel>
                            {
                                ModelCreator.CreateDietMealViewModel("0,1,2,3,4", 540),
                                ModelCreator.CreateDietMealViewModel("0,1,2,3,4", 690)
                            };
            var diet = ModelCreator.CreateDietViewModel();
            diet.Meals = meals;
            var dietNotifier = new DietNotifier(diet, new DateTime(2013, 4, 1));
            var result = dietNotifier.GetMealsForDay(new DateTime(2013, 4, 1)); //Monday
            result.ShouldNotBeNull();
            result.ShouldBeType<List<DietMealViewModel>>();
            result.Count.ShouldEqual(2);

        }

        [TestMethod]
        public void ShouldGetIngrediensForADay()
        {
            var ingredients = new List<DietIngredientViewModel>
                                  {
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4", 540),
                                      ModelCreator.CreateDietIngredientViewModel("5,6", 540),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4", 840),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4", 540),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4,5,6", 540),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4,5,6", 540),
                                  };
            var diet = ModelCreator.CreateDietViewModel();
            diet.Ingredients = ingredients;
            var dietNotifier = new DietNotifier(diet, new DateTime(2013, 4, 1));
            var result = dietNotifier.GetIngrediensForDay(new DateTime(2013, 4, 1)); //Monday
            result.ShouldNotBeNull();
            result.ShouldBeType<List<DietIngredientViewModel>>();
            result.Count.ShouldEqual(5);

        }
    }
}
