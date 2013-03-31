using System.Linq;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.Models
{
    public class AuthorRepositoryManager : IRepositoryManager<Author>
    {
        public Author Create(Author entity, string textvalue)
        {
            return entity;
        }
    }
}