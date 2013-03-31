using System;
using System.Collections.Generic;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Fakes
{
    public class FakeCommentRepository : FakeRepository<Comment>, ICommentRepository
    {
        public IEnumerable<Comment> GetCommentsForMeal(int mealId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsForDiet(int dietId)
        {
            throw new NotImplementedException();
        }
    }
}