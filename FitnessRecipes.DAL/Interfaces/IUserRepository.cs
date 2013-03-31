using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User >
    {
        User GetByUsername(string name);
        bool Authenticate(string userName, string password);
    }
}
