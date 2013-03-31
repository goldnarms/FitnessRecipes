using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.Models
{
    public class IngredientRepositoryManager : IRepositoryManager<Ingredient>
    {
        public Ingredient Create(Ingredient entity, string textvalue)
        {
            return entity;
        }
    }
}