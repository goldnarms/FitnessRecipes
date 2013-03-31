using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.BLL.Services
{
    public class MealCalculator
    {
        private readonly Meal _meal;

        public MealCalculator(Meal meal)
        {
            _meal = meal;
        }

        public double CalculateTotalKcal()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Kcal*m.Quantity);
        }

        public double CalculateTotalFat()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Fat*m.Quantity);
        }

        public double CalculateTotalProtein()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Protein*m.Quantity);
        }

        public double CalculateTotalCarb()
        {
            return _meal.MealIngredients.Sum(m => m.Ingredient.Carb*m.Quantity);
        }
    }
}