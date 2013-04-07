using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Helpers
{
    public class ScheduleHelper
    {
        public static string CreateTimeTable(DietViewModel diet)
        {
            var days = GetMaximumDays(diet);
            var meals = diet.Meals;
            var ingredients = diet.Ingredients;
            var header = CreateHeader(days);
            var body = CreateBody(days + 1, meals, ingredients);
            return string.Format("<table class='timetable'><thead><tr>{0}</tr></thead><tbody>{1}{2}</tbody></table>", header, body, CreateFooter());
        }

        public static int GetMaximumDays(DietViewModel diet)
        {

            int maxDayMeals = diet.Meals != null && diet.Meals.Any() ? diet.Meals.Max(dm => dm.Day.ToIntArray().Count()) : 0;
            int maxDayIngredients = diet.Ingredients != null && diet.Ingredients.Any() ? diet.Ingredients.Max(dm => dm.Day.ToIntArray().Count()) : 0;
            return maxDayMeals > maxDayIngredients ? maxDayMeals : maxDayIngredients;
        }

        public static string CreateBody(int days, IEnumerable<DietMealViewModel> meals, IEnumerable<DietIngredientViewModel> ingredients)
        {
            //Lag to dim array[Day][Hour] fyll med strings.
            var midnight = DateTime.Today;
            var earliestMealTime = meals != null && meals.Any() ? meals.Min(meal => meal.Time) : 1440;
            var earliestIngredientTime = ingredients != null && ingredients.Any() ? ingredients.Min(ingredient => ingredient.Time) : 1440;
            var earliestTime = earliestMealTime < earliestIngredientTime ? earliestMealTime : earliestIngredientTime;
            var earliestHour = (earliestTime / 60) - (earliestTime % 60);
            var latestMealTime = meals != null && meals.Any() ? meals.Max(meal => meal.Time) : 0;
            var latestIngredientTime = ingredients != null && ingredients.Any() ? ingredients.Max(ingredient => ingredient.Time) : 0;
            var latestTime = latestMealTime > latestIngredientTime ? latestMealTime : latestIngredientTime;
            var latestHour = (latestTime / 60) - (latestTime % 60) + 1;
            var totalHours = latestHour - earliestHour + 1;
            if (totalHours < 1)
                return "Denne dietten har ingen måltid satt opp";
            var totalMinutes = latestTime - earliestTime;
            var sortedMeals = new ScheduleViewModel[days, totalHours];
            if (meals != null && meals.Any())
            {
                foreach (var meal in meals)
                {
                    double mealHour = meal.Time / 60;
                    var hour = Math.Round(mealHour, MidpointRounding.AwayFromZero) - earliestHour;
                    var hourInt = Convert.ToInt32(hour);
                    foreach (var day in meal.Day.ToIntArray())
                    {
                        if (sortedMeals[day, hourInt] == null)
                            sortedMeals[day, hourInt] = new ScheduleViewModel { Day = day, Time = meal.Time, Name = meal.Meal.Name, Link = string.Format("<a href='/Meal/Meal/{0}' title='{1}'>- {1}</a>", meal.MealId, meal.Meal.Name) };
                        else
                        {
                            var svm = sortedMeals[day, hourInt];
                            svm.Link += string.Format("<a href='/Meal/Meal/{0}' title='{1}'>- {1}</a>", meal.MealId, meal.Meal.Name);
                            sortedMeals[day, hourInt] = svm;
                        }
                    }
                }
            }
            if (ingredients != null && ingredients.Any())
            {
                foreach (var ingredient in ingredients)
                {
                    //var hour = (ingredient.Time / 60) - (ingredient.Time % 60) - earliestHour;
                    double ingredientHour = ingredient.Time / 60;
                    var hour = Math.Round(ingredientHour, MidpointRounding.AwayFromZero) - earliestHour;
                    var hourInt = Convert.ToInt32(hour);
                    foreach (var day in ingredient.Day.ToIntArray())
                    {
                        if (sortedMeals[day, hourInt] == null)
                            sortedMeals[day, hourInt] = new ScheduleViewModel { Day = day, Time = ingredient.Time, Name = ingredient.Ingredient.Name, Link = string.Format("<a href='/Ingredient/Details/{0}' title='{1}' >- {1}</a>", ingredient.IngredientId, ingredient.Ingredient.Name) };
                        else
                        {
                            var svm = sortedMeals[day, hourInt];
                            svm.Link += string.Format("<a href='/Ingredient/Details/{0}' title='{1}' >- {1}</a>", ingredient.IngredientId, ingredient.Ingredient.Name);
                            sortedMeals[day, hourInt] = svm;
                        }
                    }
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < totalHours; i++)
            {
                sb.Append(i % 2 == 0 ? "<tr class='alternative'>" : "<tr class='rowblack'>");
                for (int j = -1; j < 7; j++)
                {
                    if (j == -1)
                    {
                        sb.Append(string.Format("<td>{0} - {1}</td>", midnight.AddMinutes((i + earliestHour) * 60).ToShortTimeString(), midnight.AddMinutes((i + earliestHour) * 60 + 60).ToShortTimeString()));
                    }
                    else
                    {
                        var d = CalculateDay(j, days);
                        if (sortedMeals[d, i] != null)
                        {
                            var svm = sortedMeals[CalculateDay(j, days), i];
                            //sb.Append(string.Format("<td><a href='/Meal/Meal/{0}' title='{1}'>{1}</a>{2}<div class='tooltip_text'><div class='tooltip_content'><a href='/Meal/Meal/{0}' title='{1}'>{1}</a>{2}</div></div></td>", dm.MealId, dm.Meal.Name, midnight.AddMinutes(dm.Time).ToShortTimeString()));
                            sb.Append(string.Format("<td class='event'>{1}{0}</td>", svm.Link, midnight.AddMinutes(svm.Time).ToShortTimeString()));
                            //sb.Append("<td>test</td>");
                        }
                        else
                        {
                            sb.Append(string.Format("<td>&nbsp;</td>"));
                        }
                    }
                }
                sb.Append("</tr>");
            }
            return sb.ToString();

        }

        private static string CreateFooter()
        {
            var sb = new StringBuilder();
            //sb.Append("<tr><td class='last' colspan='8'><div class='tip'> Hover over table block to get additional info </div></td></tr>");
            //sb.Append("<tr><td class='last' colspan='8'>&nbsp;</td></tr>");
            return sb.ToString();
        }
        public static List<ScheduleViewModel> GenerateSchedule(DietViewModel diet)
        {
            var list = new List<ScheduleViewModel>();
            foreach (var ingredient in diet.Ingredients)
            {
                list.AddRange(ingredient.Day.ToIntArray().Select(day => new ScheduleViewModel { Day = day, Time = ingredient.Time, Name = ingredient.Ingredient.Name, Link = string.Format("<a href='/Ingredient/Details/{0}' title='{1}'>{2}</a>", ingredient.IngredientId, ingredient.Ingredient.Name, ingredient.Ingredient.Name.Shorten(33)) }));
            }
            foreach (var meal in diet.Meals)
            {
                list.AddRange(meal.Day.ToIntArray().Select(day => new ScheduleViewModel { Day = day, Time = meal.Time, Name = meal.Meal.Name, Link = string.Format("<a href='/Meal/Meal/{0}' title='{1}'>{2}</a>", meal.MealId, meal.Meal.Name, meal.Meal.Name.Shorten(33)) }));
            }
            return list;
        }

        private static int CalculateDay(int day, int days)
        {
            var res = day % days;
            return res;
            if (day == days)
                return 0;
            else if (day > days)
                return (days - (day % days));
            return day;
        }

        private static string CreateHeader(int days)
        {
            var sb = new StringBuilder();
            sb.Append("<th></th>");
            for (int i = 0; i < 7; i++)
            {
                sb.Append(string.Format("<th>{0}</th>", Enum.GetName(typeof(Days), i)));
            }

            return sb.ToString();
        }

        public enum Days
        {
            Mandag,
            Tirsdag,
            Onsdag,
            Torsdag,
            Fredag,
            Lørdag,
            Søndag
        }
    }
}