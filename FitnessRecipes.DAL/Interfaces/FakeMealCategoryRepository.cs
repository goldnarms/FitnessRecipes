using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Interfaces
{
    public class FakeMealCategoryRepository : FakeRepository<MealCategory>, IMealCategoryRepository
    {
    }
}