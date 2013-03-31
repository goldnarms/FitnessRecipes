using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    interface IUnitOfWork
    {
        IRepository<Author> Authors { get; }
        IRepository<MealCategory> Categories { get; }
        IRepository<QuantityType> QuantityTypes { get; }
        IRepository<Recipe> Recipes { get; }
        void Commit();
    }
}
