using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeMealRepository : FakeRepository<Meal>, IMealRepository
    {
    }
}