using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository()
        {
            
        }

        public BrandRepository(FitnessRecipiesEntities context): base(context)
        {
        }

        public override Brand Get(int id)
        {
            return DbSet.SingleOrDefault(brand => brand.Id == id);
        }

        public override IEnumerable<Brand> GetAll()
        {
            return DbSet;
        }
    }
}
