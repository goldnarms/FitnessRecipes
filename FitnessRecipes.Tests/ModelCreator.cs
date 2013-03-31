using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Tests
{
    public static class ModelCreator
    {
        public static DietViewModel CreateDietViewModel()
        {
            return new DietViewModel
                       {
                           Name = "TestDiett",
                           Carb = 10,
                           Protein = 10,
                           Kcal = 100,
                           Fat = 10
                       };
        }

        public static DietMealViewModel CreateDietMealViewModel(string day = "1", int time =  540)
        {
            return new DietMealViewModel
                       {
                           Day = day,
                           Diet = CreateDietViewModel(),
                           Meal = CreateMealViewModel(),
                           Time = time
                       };
        }

        public static DietIngredientViewModel CreateDietIngredientViewModel(string day = "1", int time = 540)
        {
            return new DietIngredientViewModel
            {
                Day = day,
                Diet = CreateDietViewModel(),
                Ingredient = CreateIngredientViewModel(),
                Time = time
            };
        }

        public static IngredientViewModel CreateIngredientViewModel()
        {
            return new IngredientViewModel
                       {
                           Carb = 10,
                           Name = "TestIngredient",
                           Fat = 12,
                           Kcal = 120,
                       };
        }

        public static MealViewModel CreateMealViewModel()
        {
            return new MealViewModel
                       {
                           Carb = 10,
                           Name = "TestMeal",
                           Fat = 12,
                           Kcal = 120,
                           Recipe = CreateRecipeViewModel()

                       };
        }

        public static RecipeViewModel CreateRecipeViewModel()
        {
            return new RecipeViewModel
                       {
                           Notes = "testNotes",
                           User = CreateUserViewModel(),
                           Ingredients = new List<MealIngredientViewModel>(),
                       };
        }

        public static UserViewModel CreateUserViewModel()
        {
            return new UserViewModel
                       {
                           Email = "test@test.com",
                           Username = "testuser"
                       };
        }

        public static Diet CreateDiet()
        {
            return new Diet() {Name = "BatmanDiet", Description = "BatmanDietBeskrivelse"};
        }

        public static Ingredient CreateIngredient()
        {
            return new Ingredient
            {
                Carb = 10,
                Name = "TestIngredient",
                Fat = 12,
                Kcal = 120,
                Protein = 34
            };

        }

        public static Meal CreateMeal()
        {
            return new Meal
            {
                Name = "TestMeal"
            };
        }

        public static DietMeal CreateDietMeal(Diet diet, Meal meal)
        {
            return new DietMeal {Day = "0,1", Diet = diet, Meal = meal, Time = 540};
        }

        public static DietIngredient CreateDietIngredient(Diet diet, Ingredient ingredient)
        {
            return new DietIngredient
                       {
                           Day = "0,1",
                           Diet = diet,
                           Ingredient = ingredient,
                           Quantity = 2,
                           Time = 900,
                           QuantityType = new QuantityType {Id = 3, Name = "Test", IsDeleted = false}
                       };
        }

        public static MealIngredient CreateMealIngredients(Meal meal, Ingredient ingredient, QuantityType quantityType)
        {
            return new MealIngredient
                       {
                           Ingredient = ingredient,
                           Meal = meal,
                           Quantity = 3,
                           Optional = false,
                           QuantityType = quantityType
                       };
        }

        public static QuantityType CreateQuantityType(int id)
        {
            return new QuantityType {Id = id, IsDeleted = false, Name = "1 gram"};
        }
    }
}
