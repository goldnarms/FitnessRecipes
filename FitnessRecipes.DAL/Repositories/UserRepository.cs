using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FitnessRecipiesEntities context) : base(context)
        {
        }

        public override User Get(int id)
        {
            return DbSet.SingleOrDefault(user => user.Id == id);
        }

        public override IEnumerable<User> GetAll()
        {
            return DbSet.Where(user => !user.IsDeleted);
        }

        public User GetByUsername(string name)
        {
            return DbSet.SingleOrDefault(user => !user.IsDeleted && user.Username == name);
        }

        public bool Authenticate(string userName, string password)
        {
            return DbSet.Any(user => user.Username.ToLower() == userName.ToLower() && user.Password == password);
        }
    }
}
