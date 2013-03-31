﻿using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(FitnessRecipiesEntities context) : base(context)
        {
        }

        public override Comment Get(int id)
        {
            return DbSet.SingleOrDefault(comment => comment.Id == id && !comment.IsDeleted);
        }

        public override IEnumerable<Comment> GetAll()
        {
            return DbSet.Where(comment => !comment.IsDeleted);
        }

        public IEnumerable<Comment> GetCommentsForMeal(int mealId)
        {
            return DbSet.Where(comment => comment.Meal.Id == mealId);
        }

        public IEnumerable<Comment> GetCommentsForDiet(int dietId)
        {
            return DbSet.Where(comment => comment.Diet.Id == dietId);
        }
    }
}
