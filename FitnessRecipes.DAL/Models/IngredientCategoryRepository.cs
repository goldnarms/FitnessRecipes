using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessRecipes.DAL.Models
{
    public class IngredientCategoryRepository : Repository<IngredientCategory>
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
