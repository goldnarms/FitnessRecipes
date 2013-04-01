using System;
using System.Collections.Generic;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
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
