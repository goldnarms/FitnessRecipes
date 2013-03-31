using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
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
