using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeIngredientRepository : FakeRepository<Ingredient>, IIngredientRepository
    {
        public FakeIngredientRepository()
        {
            
        }
    }
}
