using System;
using System.Collections.Generic;
using System.Linq;
using FitnessRecipes.DAL.Interfaces;

namespace FitnessRecipes.DAL.Models
{
    public class MealIngredientRepository : Repository<MealIngredient>, IMealIngredientRepository
    {
        public MealIngredientRepository()
        {
            
        }

        public MealIngredientRepository(FitnessRecipiesEntities context)
            : base(context)
        {
            
        }


        public override MealIngredient Get(int id)
        {
            return null;
        }

        public override IEnumerable<MealIngredient> GetAll()
        {
            return DbSet;
        }

        public void AddIngredientToMeal(int mealId, int ingredientId)
        {
            //DbSet.Add(new MealIngredient({ IngredientId = ingredientId, MealId = mealId, Quantity = quantity, QuantityTypeId = }
        }
    }
}
