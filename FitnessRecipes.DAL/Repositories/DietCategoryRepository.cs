using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class DietCategoryRepository : Repository<DietCategory>, IDietCategoryRepository
    {
        private FitnessRecipiesEntities context;

        public DietCategoryRepository(FitnessRecipiesEntities context) :base(context)
        {
            this.context = context;
        }
        public override DietCategory Get(int id)
        {
            return DbSet.SingleOrDefault(dc => !dc.IsDeleted && dc.Id == id);
        }

        public override IEnumerable<DietCategory> GetAll()
        {
            return DbSet.Where(dc => !dc.IsDeleted);
        }
    }
}
