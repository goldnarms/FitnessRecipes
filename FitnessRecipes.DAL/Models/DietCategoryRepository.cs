using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
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
