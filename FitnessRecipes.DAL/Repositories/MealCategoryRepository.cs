using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class MealCategoryRepository : Repository<MealCategory>, IMealCategoryRepository
    {
        public MealCategoryRepository(FitnessRecipiesEntities fitnessRecipiesEntities) : base(fitnessRecipiesEntities)
        {
            
        }
        public override MealCategory Get(int id)
        {
            return DbSet.SingleOrDefault(mealCategory => !mealCategory.IsDeleted && mealCategory.Id == id);
        }

        public override IEnumerable<MealCategory> GetAll()
        {
            return DbSet.Where(mealCategory => !mealCategory.IsDeleted);
        }
    }
}