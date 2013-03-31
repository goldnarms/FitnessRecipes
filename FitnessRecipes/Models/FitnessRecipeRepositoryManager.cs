using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Models
{
    public class FitnessRecipeRepositoryManager : IRecipeRepositoryManager
    {
        public Recipe Create(Recipe entity, string textvalue)
        {
            return entity;
        }

        public Recipe Create(Recipe entity, string textvalue, IEnumerable<MealIngredientViewModel> list)
        {
            return entity;
        }
    }
}