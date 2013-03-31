using System.Linq;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository()
        {
            
        }

        public IngredientRepository(FitnessRecipiesEntities context) : base(context)
        {
        }

        public override Ingredient Get(int id)
        {
            return DbSet.SingleOrDefault(ingredient => ingredient.ID == id);
        }
    }
}
