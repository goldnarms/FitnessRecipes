using System.Linq;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Services
{
    public class MealCalculator
    {
        private readonly Meal _meal;
        private readonly IIngredientQuantityRepository _ingredientQuantityRepository;

        public MealCalculator(Meal meal, IIngredientQuantityRepository ingredientQuantityRepository)
        {
            _meal = meal;
            _ingredientQuantityRepository = ingredientQuantityRepository;
        }

        public double CalculateTotalKcal()
        {
            var totalKcals = 0d;
            foreach (var mealIngredient in _meal.MealIngredients)
            {
                var convertFactor = _ingredientQuantityRepository.GetConvertFactor(mealIngredient.IngredientId, mealIngredient.QuantityTypeId);
                var quantityConvert = QuantityConverter.ConvertTo100Grams(mealIngredient.QuantityTypeId, convertFactor);
                totalKcals += mealIngredient.Ingredient.Kcal / quantityConvert * mealIngredient.Quantity;
            }

            return _meal.MealIngredients.Sum(m => m.Ingredient.Kcal * m.Quantity / QuantityConverter.ConvertTo100Grams(m.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(m.IngredientId, m.QuantityTypeId)));
        }

        public double CalculateTotalFat()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Fat * m.Quantity / QuantityConverter.ConvertTo100Grams(m.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(m.IngredientId, m.QuantityTypeId)));
        }

        public double CalculateTotalProtein()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Protein * m.Quantity / QuantityConverter.ConvertTo100Grams(m.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(m.IngredientId, m.QuantityTypeId)));
        }

        public double CalculateTotalCarb()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Carb * m.Quantity / QuantityConverter.ConvertTo100Grams(m.QuantityTypeId, _ingredientQuantityRepository.GetConvertFactor(m.IngredientId, m.QuantityTypeId)));
        }
    }
}