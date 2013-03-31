using System.Collections;
using System.Collections.Generic;
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
            return DbSet.SingleOrDefault(ingredient => ingredient.Id == id);
        }

        public override IEnumerable<Ingredient> GetAll()
        {
            return DbSet.Where(ingredient => !ingredient.IsDeleted);
        }
    }
}
