using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeUserRepository : FakeRepository<User>, IUserRepository
    {
        public User GetByUsername(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Authenticate(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}