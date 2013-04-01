using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class CategoryRepository : Repository<MealCategory>
    {
        public CategoryRepository()
        {
            
        }

        public CategoryRepository(FitnessRecipiesEntities context) : base(context)
        {
        }

        public override MealCategory Get(int id)
        {
            return DbSet.SingleOrDefault(s => s.Id == id);
        }

        public override IEnumerable<MealCategory> GetAll()
        {
            return DbSet.Where(category => !category.IsDeleted);
        }
    }
}