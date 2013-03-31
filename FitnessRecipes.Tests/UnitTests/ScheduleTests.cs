using System;
using System.Collections.Generic;
using FitnessRecipes.Helpers;
using FitnessRecipes.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace FitnessRecipes.Tests.UnitTests
{
    [TestClass]
    public class ScheduleTests
    {
        [TestMethod]
        public void ShouldCreateTimetable()
        {

        }

        [TestMethod]
        public void ShouldCreateTimetableBody()
        {
            var days = 7;
            var meals = new List<DietMealViewModel>
                            {
                                ModelCreator.CreateDietMealViewModel("0,1,2,3,4", 540),
                                ModelCreator.CreateDietMealViewModel("0,1,2,3,4", 690)
                            };
            var ingredients = new List<DietIngredientViewModel>
                                  {
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4", 540),
                                      ModelCreator.CreateDietIngredientViewModel("5,6", 540),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4", 840),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4", 540),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4,5,6", 540),
                                      ModelCreator.CreateDietIngredientViewModel("0,1,2,3,4,5,6", 540),
                                  };
            var result = ScheduleHelper.CreateBody(days, meals, ingredients);
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void ShouldGetMaximumDays()
        {
            var meals = new List<DietMealViewModel>
                            {
                                ModelCreator.CreateDietMealViewModel(),
                                ModelCreator.CreateDietMealViewModel()
                            };
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
            diet.Meals = meals;
            diet.Ingredients = ingredients;
            var result = ScheduleHelper.GetMaximumDays(diet);
            result.ShouldEqual(6);
        }
    }
}
