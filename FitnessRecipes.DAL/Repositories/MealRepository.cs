using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        public MealRepository()
        {
            
        }

        public MealRepository(FitnessRecipiesEntities context) : base(context)
        {
            
        }
        public override Meal Get(int id)
        {
            return DbSet.SingleOrDefault(m => m.Id == id && !m.IsDeleted);
        }

        public override IEnumerable<Meal> GetAll()
        {
            return DbSet.Where(meal => !meal.IsDeleted);
        }

        public override int Remove(Meal meal)
        {
            var mealIngredients = meal.MealIngredients;
            foreach (var mealIngredient in mealIngredients)
            {
                Context.MealIngredients.Remove(mealIngredient);
                Context.SaveChanges();
            }
            DbSet.Remove(meal);
            return Context.SaveChanges();
        }
    }
}
