using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Repositories;

namespace FitnessRecipes.DAL.Models
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository()
        {
            
        }

        public RecipeRepository(FitnessRecipiesEntities context) : base(context)
        {
        }

        public override Recipe Get(int id)
        {
            return DbSet.SingleOrDefault(s => s.MealId == id);
        }

        public override IEnumerable<Recipe> GetAll()
        {
            return DbSet.Where(recipe => !recipe.Meal.IsDeleted);
        }
    }
}