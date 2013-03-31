using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Helpers
{
    public class DietNotifier
    {
        private readonly DietViewModel _diet;
        private readonly DateTime _date;

        public DietNotifier(DietViewModel diet, DateTime date)
        {
            _diet = diet;
            _date = date;
        }

        public List<DietMealViewModel> GetMealsForDay(DateTime day)
        {
            var dietMeals =
                _diet.Meals.Where(dietmeal => StringExtensions.ToIntArray(dietmeal.Day).Contains((int)day.DayOfWeek)).ToList();
            return dietMeals;
        }

        public List<DietIngredientViewModel> GetIngrediensForDay(DateTime day)
        {
            var dietIngrediens =
                _diet.Ingredients.Where(dietingredient => dietingredient.Day.ToIntArray().Contains((int)day.DayOfWeek)).ToList();
            return dietIngrediens;
        }

        public override string ToString()
        {
            var meals = GetMealsForDay(_date);
            var ingredients = GetIngrediensForDay(_date);
            var sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var ingredientViewModel in ingredients.Where(ingredient => ingredient.Time.ToDateTime().Hour > DateTime.Now.Hour - 2 && ingredient.Time.ToDateTime().Hour < DateTime.Now.Hour + 2))
            {
                sb.Append(string.Format("<li>{0}({1})</li>", ingredientViewModel.Ingredient.Name,
                                        ingredientViewModel.Time.ToTimeString()));
            }
            foreach (var dietMealViewModel in meals.Where(meal => meal.Time.ToDateTime().Hour > DateTime.Now.Hour - 2 && meal.Time.ToDateTime().Hour < DateTime.Now.Hour + 2))
            {
                sb.Append(string.Format("<li>{0}({1})</li>", dietMealViewModel.Meal.Name,
                                        dietMealViewModel.Time.ToTimeString()));
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

    }
}