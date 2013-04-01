using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeMealIngredientRepository : FakeRepository<MealIngredient>, IMealIngredientRepository
    {
        public void AddIngredientToMeal(int mealId, int ingredientId)
        {
            throw new System.NotImplementedException();
        }
    }
}