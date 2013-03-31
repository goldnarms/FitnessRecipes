using System.Collections.Generic;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Models
{
    public interface IRepositoryManager<T> where T : class
    {
        T Create(T entity, string textvalue);
    }
}
