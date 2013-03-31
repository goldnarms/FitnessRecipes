using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Interfaces
{
    public interface IDietIngredientRepository : IRepository<DietIngredient>
    {
        void RemoveIngredientFromDiet(int dietId, int ingredientId);
    }
}
