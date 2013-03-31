using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class UserDietRepository : Repository<UserDiet>, IUserDietRepository
    {
        public UserDietRepository()
        {
            
        }

        public UserDietRepository(FitnessRecipiesEntities context)
            : base(context)
        {
        }
        public override UserDiet Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<UserDiet> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
