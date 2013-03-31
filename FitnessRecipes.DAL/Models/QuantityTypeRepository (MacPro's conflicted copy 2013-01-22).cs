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
            return DbSet.SingleOrDefault(s => s.ID == id);
        }
    }
}