using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using Recipe = FitnessRecipes.Resources.Models.Recipe;

namespace FitnessRecipes.ViewModels
{
    public class RecipeViewModel
    {
        private readonly FitnessRecipiesEntities _entities;
        private readonly AuthorRepository _authorRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly MealIngredientRepository _mealIngredientRepository;
        private readonly DietRepository _dietRepository;
        public int MealId { get; set; }
        [Display(ResourceType = typeof (Recipe), Name = "Link", Prompt = "LinkPlaceholder")]
        public string WebUrl { get; set; }
        [Display(ResourceType = typeof (Recipe), Name = "Blogger", Prompt = "BloggerPlaceholder")]
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public MealViewModel Meal { get; set; }
        [Display(ResourceType = typeof (Recipe), Name = "Notes", Prompt = "NotesPlaceholder")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [Display(ResourceType = typeof (Recipe), Name = "Description", Prompt = "DescriptionPlaceholder")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public RecipeViewModel()
        {
            _entities = new DbContextFactory().GetFitnessRecipeEntities();
            _authorRepository = new AuthorRepository(_entities);
            _categoryRepository = new CategoryRepository(_entities);
            _mealIngredientRepository = new MealIngredientRepository(_entities);
            _dietRepository = new DietRepository(_entities);
        }

        public IEnumerable<DietViewModel> Diets 
        { 
            get { return Mapper.Map<IEnumerable<Diet>, IEnumerable<DietViewModel>>(_dietRepository.Query(diet => diet.DietMeals.Any(dm => dm.Meal.Id == this.Meal.Id))); } 
        }
        public IEnumerable<MealIngredientViewModel> Ingredients { get; set; }
        public IEnumerable<AuthorViewModel> Authors
        {
            get
            {
                return Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorViewModel>>(_authorRepository.GetAll()).ToList();
            }
        }
        public IEnumerable<MealCategoryViewModel> Categories
        {
            get
            {
                return Mapper.Map<IEnumerable<MealCategory>, IEnumerable<MealCategoryViewModel>>(_categoryRepository.GetAll()).ToList();
            }
        }

        public double Kcal
        {
            get {
                var ingredients = _mealIngredientRepository.Query(ri => ri.MealId == MealId);
                return ingredients.Sum(ingredientViewModel => (ingredientViewModel.Ingredient.Kcal*ingredientViewModel.Quantity / QuantityConverter.ConvertTo100Grams(ingredientViewModel.QuantityTypeId)));
            }
        }

        public double Protein
        {
            get
            {
                var ingredients = _mealIngredientRepository.Query(ri => ri.MealId == MealId);
                return ingredients.Sum(ingredientViewModel => (ingredientViewModel.Ingredient.Protein * ingredientViewModel.Quantity / QuantityConverter.ConvertTo100Grams(ingredientViewModel.QuantityTypeId)));
            }
        }

        public double Fat
        {
            get
            {
                var ingredients = _mealIngredientRepository.Query(ri => ri.MealId == MealId);
                return ingredients.Sum(ingredientViewModel => (ingredientViewModel.Ingredient.Fat * ingredientViewModel.Quantity / QuantityConverter.ConvertTo100Grams(ingredientViewModel.QuantityTypeId)));
            }
        }

        public double Carb
        {
            get
            {
                var ingredients = _mealIngredientRepository.Query(ri => ri.MealId == MealId);
                return ingredients.Sum(ingredientViewModel => (ingredientViewModel.Ingredient.Carb * ingredientViewModel.Quantity / QuantityConverter.ConvertTo100Grams(ingredientViewModel.QuantityTypeId)));
            }
        }
    }
}
