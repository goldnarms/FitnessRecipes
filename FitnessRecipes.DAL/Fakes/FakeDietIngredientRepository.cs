using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeDietIngredientRepository : FakeRepository<DietIngredient>, IDietIngredientRepository
    {
        public void RemoveIngredientFromDiet(int dietId, int ingredientId)
        {
            if(_dictionary.Any(di => di.Value.IngredientId == ingredientId && di.Value.DietId == dietId))
            {
                _dictionary.Remove(
                    _dictionary.FirstOrDefault(di => di.Value.IngredientId == ingredientId && di.Value.DietId == dietId)
                        .Key);
            }
        }
    }
}