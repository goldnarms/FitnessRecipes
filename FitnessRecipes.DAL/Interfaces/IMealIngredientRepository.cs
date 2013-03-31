using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessRecipes.DAL.Interfaces
{
    public interface IMealIngredientRepository
    {
        void AddIngredientToMeal(int mealId, int ingredientId);
    }
}
