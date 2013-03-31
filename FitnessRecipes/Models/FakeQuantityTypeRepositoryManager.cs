using System;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.Models
{
    public class FakeQuantityTypeRepositoryManager : IRepositoryManager<QuantityType>
    {
        public QuantityType Create(QuantityType entity, string textvalue)
        {
            throw new NotImplementedException();
        }
    }
}