using System;
using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class IngredientQuantityRepository : Repository<IngredientQuantity>, IIngredientQuantityRepository
    {
        public IngredientQuantityRepository()
        {

        }

        public IngredientQuantityRepository(FitnessRecipiesEntities context)
            : base(context)
        {

        }
        public override IngredientQuantity Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IngredientQuantity> GetAll()
        {
            throw new NotImplementedException();
        }

        public double GetConvertFactor(int ingredientId, int quantityTypeId = 14)
        {
            var result = DbSet.SingleOrDefault(iq => iq.IngredientId == ingredientId && iq.QuantitytypeId == quantityTypeId);
            return result != null ? result.To100Ggram : 1;
        }
    }
}
