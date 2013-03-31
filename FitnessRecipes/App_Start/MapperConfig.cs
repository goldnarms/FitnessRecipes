using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Helpers;
using FitnessRecipes.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.App_Start
{
    public class MapperConfig
    {        
        public static void ConfigureMapper()
        {
            //var ent = new DbContextFactory().GetFitnessRecipeEntities();
            //var dietRepository = new DietRepository(ent);
            //var dietIngredientRepository = new DietIngredientRepository(ent);
            //var dietMealRepository = new DietMealRepository(ent);
            //var mealIngredientRepository = new MealIngredientRepository(ent);
            //var mealRepository = new MealRepository(ent);

            //var dietIngredients = dietIngredientRepository.GetAll();
            //var dietMeals = dietMealRepository.GetAll();
            //var mealIngredients = mealIngredientRepository.GetAll();
            //var meals = mealRepository.GetAll();

            //var kcalForMeal = new Dictionary<int, double>();
            //var carbsForMeal = new Dictionary<int, double>();
            //var fatForMeal = new Dictionary<int, double>();
            //var proteinForMeal = new Dictionary<int, double>();

            //foreach (var meal in meals)
            //{
            //    var mealIngredientsForMeal = mealIngredients.Where(mi => mi.MealId == meal.Id);
                
            //    var sumCarb = mealIngredientsForMeal.Sum(mi => mi.Ingredient.Carb * mi.Quantity / QuantityConverter.ConvertTo100Grams(mi.QuantityTypeId));
            //    carbsForMeal.Add(meal.Id, sumCarb);
            //    var sumProtein = mealIngredientsForMeal.Sum(mi => mi.Ingredient.Protein * mi.Quantity / QuantityConverter.ConvertTo100Grams(mi.QuantityTypeId));
            //    proteinForMeal.Add(meal.Id, sumProtein );
            //    var sumFat = mealIngredientsForMeal.Sum(mi => mi.Ingredient.Fat * mi.Quantity / QuantityConverter.ConvertTo100Grams(mi.QuantityTypeId));
            //    fatForMeal.Add(meal.Id, sumFat);
            //    var sumKcal = mealIngredientsForMeal.Sum(mi => mi.Ingredient.Kcal * mi.Quantity / QuantityConverter.ConvertTo100Grams(mi.QuantityTypeId));
            //    kcalForMeal.Add(meal.Id, sumKcal);
            //}

            //var carbsForDiet = new Dictionary<int, double>();
            //var fatForDiet = new Dictionary<int, double>();
            //var proteinForDiet = new Dictionary<int, double>();
            //foreach (var diets in dietRepository.GetAll())
            //{
            //    var dietIngredientsForDiet = dietIngredients.Where(di => di.DietId == diets.Id);
            //    var dietMealsForDiet = dietMeals.Where(dm => dm.DietId == diets.Id);

            //    var sumCarb = dietIngredientsForDiet.Sum(di => di.Ingredient.Carb);
            //    var mealSumCarb = dietMealsForDiet.Sum(dm => dm.Meal.MealIngredients.Sum(mi => mi.Ingredient.Carb));
            //    carbsForDiet.Add(diets.Id, sumCarb + mealSumCarb);
            //    var sumProtein = dietIngredientsForDiet.Sum(di => di.Ingredient.Protein);
            //    var mealSumProtein = dietMealsForDiet.Sum(dm => dm.Meal.MealIngredients.Sum(mi => mi.Ingredient.Protein));
            //    proteinForDiet.Add(diets.Id, sumProtein + mealSumProtein);
            //    var sumFat = dietIngredientsForDiet.Sum(di => di.Ingredient.Fat);
            //    var mealSumFat = dietMealsForDiet.Sum(dm => dm.Meal.MealIngredients.Sum(mi => mi.Ingredient.Fat));
            //    fatForDiet.Add(diets.Id, sumFat + mealSumFat);
            //}
            Mapper.CreateMap<Author, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, Author>();
            Mapper.CreateMap<Ingredient, IngredientViewModel>()
                .ForMember(ingredientViewModel => ingredientViewModel.Ingredients, ingredient => ingredient.MapFrom(r => r.Ingredient1));
            Mapper.CreateMap<IngredientViewModel, Ingredient>();
            Mapper.CreateMap<Recipe, RecipeViewModel>()
                .ForMember(recipeViewModel => recipeViewModel.Ingredients, recipe => recipe.MapFrom(r => r.Meal.MealIngredients));
            Mapper.CreateMap<Meal, MealViewModel>();
                //.ForMember(mealViewModel => mealViewModel.Ingredients, meal => meal.MapFrom(m => m.MealIngredients))
                //.ForMember(mealViewModel => mealViewModel.Carb, meal => meal.MapFrom(m => carbsForMeal.ContainsKey(m.Id) ? carbsForMeal[m.Id] : 0))
                //.ForMember(mealViewModel => mealViewModel.Protein, meal => meal.MapFrom(m => proteinForMeal.ContainsKey(m.Id) ? proteinForMeal[m.Id] : 0))
                //.ForMember(mealViewModel => mealViewModel.Kcal, meal => meal.MapFrom(m => kcalForMeal.ContainsKey(m.Id) ? kcalForMeal[m.Id] : 0))
                //.ForMember(mealViewModel => mealViewModel.Fat, meal => meal.MapFrom(m => fatForMeal.ContainsKey(m.Id) ? fatForMeal[m.Id] : 0));
            Mapper.CreateMap<MealViewModel, Meal>();
            Mapper.CreateMap<RecipeViewModel, Recipe>();
            Mapper.CreateMap<MealCategory, MealCategoryViewModel>();
            Mapper.CreateMap<MealCategoryViewModel, MealCategory>();
            Mapper.CreateMap<QuantityTypeViewModel, QuantityType>();
            Mapper.CreateMap<QuantityType, QuantityTypeViewModel>();
            Mapper.CreateMap<DietViewModel, Diet>();
            Mapper.CreateMap<Diet, DietViewModel>();
                //.ForMember(dietViewModel => dietViewModel.Name, diet => diet.MapFrom(q => q.Name))
                //.ForMember(dietViewModel => dietViewModel.Meals, meal => meal.MapFrom(m => m.DietMeals))
                //.ForMember(dietViewModel => dietViewModel.Ingredients, meal => meal.MapFrom(m => m.DietIngredients))
                //.ForMember(dietViewModel => dietViewModel.Carb, diet => diet.MapFrom(d => carbsForDiet.ContainsKey(d.Id) ? carbsForDiet[d.Id] : 0))
                //.ForMember(dietViewModel => dietViewModel.Protein, diet => diet.MapFrom(d => proteinForDiet.ContainsKey(d.Id) ? proteinForDiet[d.Id] : 0))
                //.ForMember(dietViewModel => dietViewModel.Fat, diet => diet.MapFrom(d => fatForDiet.ContainsKey(d.Id) ? fatForDiet[d.Id] : 0));
            Mapper.CreateMap<DietCategoryViewModel, DietCategory>();
            Mapper.CreateMap<DietCategory, DietCategoryViewModel>();
            Mapper.CreateMap<DietMeal, DietMealViewModel>().Bidirectional();
            Mapper.CreateMap<DietIngredient, DietIngredientViewModel>().Bidirectional();
            Mapper.CreateMap<MealIngredient, MealIngredientViewModel>().Bidirectional();
            Mapper.CreateMap<IngredientCategory, IngredientCategoryViewModel>().Bidirectional();
            Mapper.CreateMap<Comment, CommentViewModel>().Bidirectional();
            Mapper.CreateMap<User, UserViewModel>().Bidirectional();
            Mapper.CreateMap<Brand, BrandViewModel>().Bidirectional();
            //Mapper.AssertConfigurationIsValid();
        }
    }
}