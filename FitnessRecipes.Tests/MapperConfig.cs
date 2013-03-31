using AutoMapper;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Helpers;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Tests
{
    public class MapperConfig
    {
        public static void ConfigureMapper()
        {
            Mapper.CreateMap<Author, AuthorViewModel>().Bidirectional();
            Mapper.CreateMap<Brand, BrandViewModel>().Bidirectional();
            Mapper.CreateMap<Comment, CommentViewModel>().Bidirectional();
            Mapper.CreateMap<Diet, DietViewModel>().Bidirectional();
            Mapper.CreateMap<DietCategory, DietCategoryViewModel>().Bidirectional();
            Mapper.CreateMap<DietIngredient, DietIngredientViewModel>().Bidirectional();
            Mapper.CreateMap<DietMeal, DietMealViewModel>().Bidirectional();
            Mapper.CreateMap<Ingredient, IngredientViewModel>().Bidirectional();
            Mapper.CreateMap<IngredientCategory, IngredientCategoryViewModel>().Bidirectional();
            Mapper.CreateMap<Meal, MealViewModel>().Bidirectional();
            Mapper.CreateMap<MealCategory, MealCategoryViewModel>().Bidirectional();
            Mapper.CreateMap<MealIngredient, MealIngredientViewModel>().Bidirectional();
            Mapper.CreateMap<QuantityType, QuantityTypeViewModel>().Bidirectional();
            Mapper.CreateMap<Recipe, RecipeViewModel>().Bidirectional();
            Mapper.CreateMap<User, UserViewModel>().Bidirectional();
        }
    }
}
