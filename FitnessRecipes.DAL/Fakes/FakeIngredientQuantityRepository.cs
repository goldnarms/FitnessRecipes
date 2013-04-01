using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeIngredientQuantityRepository : FakeRepository<IngredientQuantity>, IIngredientQuantityRepository
    {
        public double GetConvertFactor(int ingredientId, int quantityTypeId)
        {
            if (quantityTypeId == 14 && ingredientId == 4)
                return 0.5;
            return 1;
        }
    }
}
