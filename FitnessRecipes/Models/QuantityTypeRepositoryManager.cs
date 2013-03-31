using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.Models
{
    public class QuantityTypeRepositoryManager : IRepositoryManager<QuantityType>
    {
        public QuantityType Create(QuantityType entity, string textvalue)
        {
            return entity;
        }
    }
}