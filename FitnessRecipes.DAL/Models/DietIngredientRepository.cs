using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class DietIngredientRepository : Repository<DietIngredient>, IDietIngredientRepository
    {
        public DietIngredientRepository(FitnessRecipiesEntities context) : base(context)
        {
            
        }

        public void RemoveIngredientFromDiet(int dietId, int ingredientId)
        {
            DbSet.Remove(DbSet.SingleOrDefault(di => di.DietId == dietId && di.IngredientId == ingredientId));
        }

        public override DietIngredient Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<DietIngredient> GetAll()
        {
            return DbSet;
        }
    }
}
