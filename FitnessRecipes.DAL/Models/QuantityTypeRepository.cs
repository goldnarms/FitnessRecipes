using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class QuantityTypeRepository : Repository<QuantityType>, IQuantityTypeRepository
    {
        public QuantityTypeRepository()
        {
            
        }

        public QuantityTypeRepository(FitnessRecipiesEntities context) : base(context)
        {
        }

        public override QuantityType Get(int id)
        {
            return DbSet.SingleOrDefault(s => s.Id == id);
        }

        public override IEnumerable<QuantityType> GetAll()
        {
            return DbSet.Where(qt => !qt.IsDeleted);
        }
    }
}