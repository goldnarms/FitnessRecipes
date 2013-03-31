using System;
using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.BLL.Services
{
    public class DietCalculator
    {
        private readonly Diet _diet;
        private readonly double _totalIngredientFatGrams;
        private readonly double _totalMealFatGrams;
        private readonly double _totalIngredientProteinGrams;
        private readonly double _totalMealProteinGrams;
        private readonly double _totalGrams = 0;
        private readonly double _totalIngredientCarbsGrams;
        private readonly double _totalMealCarbGrams;

        public DietCalculator(Diet diet)
        {
            _diet = diet;
            _totalIngredientFatGrams = _diet.DietIngredients.Sum(di => di.Ingredient.Fat * di.Quantity * di.Day.ToIntArray().Count());
            _totalMealFatGrams = _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal).CalculateTotalFat() * dm.Day.ToIntArray().Count());
            _totalGrams += _totalIngredientFatGrams + _totalMealFatGrams;
            _totalIngredientProteinGrams = _diet.DietIngredients.Sum(di => di.Ingredient.Protein * di.Quantity * di.Day.ToIntArray().Count());
            _totalMealProteinGrams = _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal).CalculateTotalProtein() * dm.Day.ToIntArray().Count());
            _totalGrams += _totalIngredientProteinGrams + _totalMealProteinGrams;
            _totalIngredientCarbsGrams = _diet.DietIngredients.Sum(di => di.Ingredient.Carb * di.Quantity * di.Day.ToIntArray().Count());
            _totalMealCarbGrams = _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal).CalculateTotalCarb() * dm.Day.ToIntArray().Count());
            _totalGrams += _totalIngredientCarbsGrams + _totalMealCarbGrams;
        }



        public double? CalculateAverageKcal()
        {
            var totalIngredientKcals = _diet.DietIngredients.Sum(di => di.Ingredient.Kcal * di.Quantity * di.Day.ToIntArray().Count());
            var totalIngredientDays = _diet.DietIngredients.Max(di => di.Day.ToIntArray().Count());
            var totalMealKcals = _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal).CalculateTotalKcal() * dm.Day.ToIntArray().Count());
            var totalMealDays = _diet.DietMeals.Max(dm => dm.Day.ToIntArray().Count());
            var maxdays = Math.Max(totalIngredientDays, totalMealDays);
            return Convert.ToInt32((totalIngredientKcals + totalMealKcals)/maxdays);
        }

        public double? CalculateFatPercentage()
        {
            return (_totalIngredientFatGrams + _totalMealFatGrams) /_totalGrams*100;
        }

        public double? CalculateCarbPercentage()
        {
            return (_totalIngredientCarbsGrams + _totalMealCarbGrams) / _totalGrams * 100;
        }

        public double? CalculateProteinPercentage()
        {
            return (_totalIngredientProteinGrams + _totalMealProteinGrams) / _totalGrams * 100;
        }
    }
}