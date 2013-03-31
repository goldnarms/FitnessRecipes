using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Models
{
    interface IRecipeRepositoryManager : IRepositoryManager<Recipe>
    {
        Recipe Create(Recipe entity, string textvalue, IEnumerable<MealIngredientViewModel> list);
    }
}
