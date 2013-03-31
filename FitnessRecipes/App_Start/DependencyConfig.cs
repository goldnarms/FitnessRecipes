using System.Configuration;
using System.Web.Mvc;
using AdminPortal.BLL.Interfaces;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using Microsoft.Practices.Unity;
using User = FitnessRecipes.DAL.Models.User;

namespace FitnessRecipes.App_Start
{
    public static class DependencyConfig
    {
        public static void SetUpDependencies()
        {
            //string dbAsString = ConfigurationManager.AppSettings["database"];
            //if (string.IsNullOrEmpty(dbAsString))
            //{
            //    throw new ConfigurationErrorsException("'database' configuration is required.");
            //}
            var container = new UnityContainer();
            var fitnessRecipeEntites = new DbContextFactory().GetFitnessRecipeEntities();
            container.RegisterType<IRepository<Author>, AuthorRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<Brand>, BrandRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<MealCategory>, CategoryRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<Comment>, CommentRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<DietCategory>, DietCategoryRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<DietIngredient>, DietIngredientRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<DietMeal>, DietMealRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<Diet>, DietRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<Ingredient>, IngredientRepository>(new InjectionConstructor(fitnessRecipeEntites)); 
            container.RegisterType<IRepository<IngredientCategory>, IngredientCategoryRepository>(new InjectionConstructor(fitnessRecipeEntites)); 
            container.RegisterType<IRepository<IngredientQuantity>, IngredientQuantityRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<MealIngredient>, MealIngredientRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<Meal>, MealRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<QuantityType>, QuantityTypeRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<Recipe>, RecipeRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<UserDiet>, UserDietRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRepository<User>, UserRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IAuthorRepository, AuthorRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<ICommentRepository, CommentRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IDietCategoryRepository, DietCategoryRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IDietIngredientRepository, DietIngredientRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IDietMealRepository, DietMealRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IDietRepository, DietRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IIngredientRepository, IngredientRepository>(new InjectionConstructor(fitnessRecipeEntites)); 
            container.RegisterType<IIngredientQuantityRepository, IngredientQuantityRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IMealRepository, MealRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IMealIngredientRepository, MealIngredientRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IMealRepository, MealRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IQuantityTypeRepository, QuantityTypeRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IRecipeRepository, RecipeRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IUserDietRepository, UserDietRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(fitnessRecipeEntites));
            container.RegisterType<IFormsAuthentication, FormsAuth>();
            DependencyResolver.SetResolver(new Helpers.UnityDependencyResolver(container));
        }
    }
}