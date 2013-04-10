using System;
using System.Linq;
using FitnessRecipes.BLL.Interfaces;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Services
{
    public class DietCalculator
    {
        private readonly Diet _diet;
        private readonly double _totalIngredientFatGrams = 0;
        private readonly double _totalMealFatGrams = 0;
        private readonly double _totalIngredientProteinGrams = 0;
        private readonly double _totalMealProteinGrams = 0;
        private readonly double _totalGrams = 0;
        private readonly double _totalIngredientCarbsGrams = 0;
        private readonly double _totalMealCarbGrams = 0;
        private IIngredientQuantityRepository _ingredientQuantityRepository;
        private readonly ITracer _tracer;
        private double _totalIngredientKcals;
        private double _totalMealKcals;

        public DietCalculator(Diet diet, IIngredientQuantityRepository ingredientQuantityRepository, ITracer tracer)
        {
            _diet = diet;
            _ingredientQuantityRepository = ingredientQuantityRepository;
            _tracer = tracer;
            tracer.WriteTrace("Henter ut ingredienser og måltid");
            var ingredients = _diet.DietIngredients.ToList();
            var meals = _diet.DietMeals.ToList();
            foreach (var di in ingredients)
            {
                var quantityConversion = di.Quantity / QuantityConverter.ConvertTo100Grams(di.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(di.IngredientId, di.QuantityTypeId)) * di.Day.ToIntArray().Count();
                _totalIngredientCarbsGrams += di.Ingredient.Carb * quantityConversion;
                _totalIngredientFatGrams += di.Ingredient.Fat * quantityConversion;
                _totalIngredientProteinGrams += di.Ingredient.Protein * quantityConversion;
                _totalIngredientKcals += di.Ingredient.Kcal * quantityConversion;
            }


            foreach (var dm in meals)
            {
                var mealDays = dm.Day.ToIntArray().Count();
                var mealCalulator = new MealCalculator(dm.Meal, _ingredientQuantityRepository);
                _totalMealCarbGrams += mealCalulator.CalculateTotalCarb() * mealDays;
                _totalMealFatGrams += mealCalulator.CalculateTotalFat() * mealDays;
                _totalMealProteinGrams += mealCalulator.CalculateTotalProtein() * mealDays;
                _totalMealKcals += mealCalulator.CalculateTotalKcal() * mealDays;
            }

            _totalGrams = _totalIngredientCarbsGrams + _totalIngredientFatGrams + _totalIngredientProteinGrams +
                          _totalMealCarbGrams + _totalMealFatGrams + _totalMealProteinGrams;
            _tracer.WriteTrace("Ferdig med constructor");
        }



        public double? CalculateAverageKcal()
        {
            var totalIngredientDays = _diet.DietIngredients != null && _diet.DietIngredients.Count > 0 ? _diet.DietIngredients.Max(di => di.Day.ToIntArray().Count()) : 0;
            var totalMealDays = _diet.DietMeals != null && _diet.DietMeals.Count > 0 ? _diet.DietMeals.Max(dm => dm.Day.ToIntArray().Count()) : 0;
            var maxdays = Math.Max(totalIngredientDays, totalMealDays);
            _tracer.WriteTrace("Ferdig med snitt kcal");
            return (_totalIngredientKcals + _totalMealKcals) / maxdays;
        }

        public double? CalculateFatPercentage()
        {
            return (_totalIngredientFatGrams + _totalMealFatGrams) / _totalGrams * 100;
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