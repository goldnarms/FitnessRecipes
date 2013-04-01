using System;
using System.Collections.Generic;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
{
    public class DietMealRepository : Repository<DietMeal>, IDietMealRepository
    {
        public DietMealRepository(FitnessRecipiesEntities context)
            : base(context)
        {
        }
        public override DietMeal Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<DietMeal> GetAll()
        {
            return DbSet;
        }
    }
}
