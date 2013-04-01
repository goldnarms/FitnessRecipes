using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class IngredientCategoryRepository : Repository<IngredientCategory>, IIngredientCategoryRepository
    {
        public IngredientCategoryRepository()
        {

        }

        public IngredientCategoryRepository(FitnessRecipiesEntities context) : base(context)
        {
            
        }
        public override IngredientCategory Get(int id)
        {
            return DbSet.SingleOrDefault(ic => ic.Id == id);
        }

        public override IEnumerable<IngredientCategory> GetAll()
        {
            return DbSet.Where(ic => !ic.IsDeleted);
        }
    }
}
