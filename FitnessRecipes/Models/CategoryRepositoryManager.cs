using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.Models
{
    public class CategoryRepositoryManager:IRepositoryManager<MealCategory>
    {
        public MealCategory Create(MealCategory entity, string textvalue)
        {
            return entity;
        }
    }
}