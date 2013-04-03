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

        public static DietMealViewModel CreateDietMealViewModel(string day = "1", int time = 540)
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
                           IngredientId = ingredient.Id,
                           Quantity = 2,
                           Time = 900,
                           QuantityType = new QuantityType {Id = 3, Name = "Test", IsDeleted = false},
                           QuantityTypeId = 3
                       };
        }

        public static MealIngredient CreateMealIngredients(Meal meal, Ingredient ingredient, QuantityType quantityType)
        {
            return new MealIngredient
                       {
                           MealId = meal.Id,
                           IngredientId = ingredient.Id,
                           Ingredient = ingredient,
                           Meal = meal,
                           Quantity = 3,
                           Optional = false,
                           QuantityType = quantityType,
                           QuantityTypeId = quantityType.Id
                       };
        }

        public static QuantityType CreateQuantityType(int id)
        {
            return new QuantityType {Id = id, IsDeleted = false, Name = "1 gram"};
        }

        public static Diet CreateOatMealDiet()
        {
            var diet = new Diet {Name = "SuperDiett"};
            var dietMeal = new DietMeal {Day = "0,2", Diet = diet, Meal = CreateOatMeal(), Time = 900};
            diet.DietMeals = new List<DietMeal> {dietMeal};
            return diet;
        }

        public static Meal CreateOatMeal()
        {
            var milk = new Ingredient { Carb = 4.7, Fat = 0.7, Protein = 3.3, Kcal = 38, Name = "Melk", Id = 4 };
            var whey = new Ingredient { Carb = 0.4, Fat = 3, Protein = 86, Kcal = 360, Name = "Whey-100" };
            var oatMeal = new Ingredient { Carb = 61, Fat = 7, Protein = 13, Kcal = 365, Name = "Havregryn" };
            var meal = new Meal { Name = "HavreShake" };
            var glass = new QuantityType { Name = "Glass", Id = 14 };
            var mealIngredientMilk = new MealIngredient
            {
                Ingredient = milk,
                IngredientId = 4,
                Meal = meal,
                Quantity = 1.2,
                QuantityType = glass,
                QuantityTypeId = 14
            };
            var gram = new QuantityType { Name = "Gram", Id = 1 };
            var mealIngredientWhey = new MealIngredient
            {
                Ingredient = whey,
                IngredientId = 5,
                Meal = meal,
                Quantity = 37,
                QuantityType = gram,
                QuantityTypeId = 1
            };
            var mealIngredientOatMeal = new MealIngredient
            {
                Ingredient = oatMeal,
                IngredientId = 6,
                Quantity = 40,
                QuantityType = gram,
                Meal = meal,
                QuantityTypeId = 1
            };
            meal.MealIngredients = new List<MealIngredient>
                                       {
                                           mealIngredientMilk,
                                           mealIngredientOatMeal,
                                           mealIngredientWhey
                                       };
            return meal;
        }
    }
}
