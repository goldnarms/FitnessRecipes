using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class DietRepository : Repository<Diet>, IDietRepository
    {
        public DietRepository()
        {
            
        }

        public DietRepository(FitnessRecipiesEntities context)
            : base(context)
        {
        }

        public override Diet Get(int id)
        {
            return DbSet.SingleOrDefault(diet => diet.Id == id);
        }

        public override IEnumerable<Diet> GetAll()
        {
            return DbSet.Where(diet => !diet.IsDeleted);
        }
    }
}
