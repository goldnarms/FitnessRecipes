using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Interfaces
{
    public interface IMealIngredientRepository : IRepository<MealIngredient>
    {
        void AddIngredientToMeal(int mealId, int ingredientId);
    }
}
