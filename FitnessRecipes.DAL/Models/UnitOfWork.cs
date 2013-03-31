using System;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessRecipiesEntities _context;
        private AuthorRepository _authors;
        private CategoryRepository _categories;
        private QuantityTypeRepository _quantityTypes;
        private RecipeRepository _recipes;
        private IngredientRepository _ingredients;

        public UnitOfWork(FitnessRecipiesEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }

            _context = context;
        }

        public IRepository<Author> Authors
        {
            get { return _authors ?? (_authors = new AuthorRepository(_context)); }
        }

        public IRepository<MealCategory> Categories
        {
            get { return _categories ?? (_categories = new CategoryRepository(_context)); }
        }

        public IRepository<QuantityType> QuantityTypes
        {
            get { return _quantityTypes ?? (_quantityTypes = new QuantityTypeRepository(_context)); }
        }

        public IRepository<Recipe> Recipes
        {
            get { return _recipes ?? (_recipes = new RecipeRepository(_context)); }
        }

        public IRepository<Ingredient> Ingredients
        {
            get { return _ingredients ?? (_ingredients = new IngredientRepository(_context)); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
