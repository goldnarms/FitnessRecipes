using System;
using System.Linq;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Services
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
        private IIngredientQuantityRepository _ingredientQuantityRepository;

        public DietCalculator(Diet diet, IIngredientQuantityRepository ingredientQuantityRepository)
        {
            _diet = diet;
            _ingredientQuantityRepository = ingredientQuantityRepository;
            _totalIngredientFatGrams = _diet.DietIngredients != null && _diet.DietIngredients.Count > 0 ? _diet.DietIngredients.Sum(di => di.Ingredient.Fat * di.Quantity / QuantityConverter.ConvertTo100Grams(di.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(di.IngredientId, di.QuantityTypeId)) * di.Day.ToIntArray().Count()) : 0;
            _totalMealFatGrams = _diet.DietMeals != null && _diet.DietMeals.Count > 0 ? _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal, _ingredientQuantityRepository).CalculateTotalFat() * dm.Day.ToIntArray().Count()) : 0;
            _totalGrams += _totalIngredientFatGrams + _totalMealFatGrams;
            _totalIngredientProteinGrams = _diet.DietIngredients != null && _diet.DietIngredients.Count > 0 ? _diet.DietIngredients.Sum(di => di.Ingredient.Protein * di.Quantity / QuantityConverter.ConvertTo100Grams(di.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(di.IngredientId, di.QuantityTypeId)) * di.Day.ToIntArray().Count()) : 0;
            _totalMealProteinGrams = _diet.DietMeals != null && _diet.DietMeals.Count > 0 ? _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal, _ingredientQuantityRepository).CalculateTotalProtein() * dm.Day.ToIntArray().Count()) : 0;
            _totalGrams += _totalIngredientProteinGrams + _totalMealProteinGrams;
            _totalIngredientCarbsGrams = _diet.DietIngredients != null && _diet.DietIngredients.Count > 0 ? _diet.DietIngredients.Sum(di => di.Ingredient.Carb * di.Quantity / QuantityConverter.ConvertTo100Grams(di.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(di.IngredientId, di.QuantityTypeId)) * di.Day.ToIntArray().Count()) : 0;
            _totalMealCarbGrams = _diet.DietMeals != null && _diet.DietMeals.Count > 0 ? _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal, _ingredientQuantityRepository).CalculateTotalCarb() * dm.Day.ToIntArray().Count()) : 0;
            _totalGrams += _totalIngredientCarbsGrams + _totalMealCarbGrams;
        }



        public double? CalculateAverageKcal()
        {
            var totalIngredientKcals = _diet.DietIngredients != null && _diet.DietIngredients.Count > 0 ? _diet.DietIngredients.Sum(di => di.Ingredient.Kcal * di.Quantity / QuantityConverter.ConvertTo100Grams(di.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(di.IngredientId, di.QuantityTypeId)) * di.Day.ToIntArray().Count()) : 0;
            var totalIngredientDays = _diet.DietIngredients != null && _diet.DietIngredients.Count > 0 ? _diet.DietIngredients.Max(di => di.Day.ToIntArray().Count()) : 0;
            var totalMealKcals = _diet.DietMeals != null && _diet.DietMeals.Count > 0 ? _diet.DietMeals.Sum(dm => new MealCalculator(dm.Meal, _ingredientQuantityRepository).CalculateTotalKcal() * dm.Day.ToIntArray().Count()) : 0;
            var totalMealDays = _diet.DietMeals != null && _diet.DietMeals.Count > 0 ? _diet.DietMeals.Max(dm => dm.Day.ToIntArray().Count()) : 0;
            var maxdays = Math.Max(totalIngredientDays, totalMealDays);
            return (totalIngredientKcals + totalMealKcals)/maxdays;
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