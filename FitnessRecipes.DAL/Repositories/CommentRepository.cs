using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.DAL.Repositories
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

        public IEnumerable<Comment> GetLatestCommentsForUser(int userId, int size = 3)
        {
            var commentsForUser = DbSet.Where(comment => comment.UserId == userId || comment.Comment2.UserId == userId || comment.Comment1.Any(c => c.UserId == userId));
            return commentsForUser.OrderByDescending(c => c.DateAdded).Take(3);
        }
    }
}
