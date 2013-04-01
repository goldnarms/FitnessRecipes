using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository()
        {
            
        }
        public AuthorRepository(FitnessRecipiesEntities context)
            : base(context)
        {
        }

        public override Author Get(int id)
        {
            return DbSet.SingleOrDefault(s => s.UserId == id);
        }

        public override IEnumerable<Author> GetAll()
        {
            return DbSet;
        }
    }
}