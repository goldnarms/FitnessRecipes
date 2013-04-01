using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeIngredientCategoryRepository : FakeRepository<IngredientCategory>, IIngredientCategoryRepository
    {
    }
}