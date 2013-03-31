using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Resources.Common;
using Ingredient = FitnessRecipes.Resources.Models.Ingredient;

namespace FitnessRecipes.ViewModels
{
    public class IngredientViewModel
    {
        private readonly FitnessRecipiesEntities _entities;
        private readonly RecipeRepository _recipeRepository;

        public IngredientViewModel()
        {
            _entities = new DbContextFactory().GetFitnessRecipeEntities();
            _recipeRepository = new RecipeRepository(_entities);
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(ResourceType = typeof (Ingredient), Name = "Name", Prompt = "NamePlaceholder")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }
        public int? IngredientId { get; set; }
        [Display(ResourceType = typeof (Ingredient), Name = "Carbs", Prompt = "CarbsPlaceholder")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public double Carb { get; set; }
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof (Ingredient), Name = "Protein", Prompt = "ProteinPlaceholder")]
        public double Protein { get; set; }
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof (Ingredient), Name = "Fat", Prompt = "FatPlaceholder")]
        public double Fat { get; set; }
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof (Ingredient), Name = "Calories", Prompt = "CaloriesPlaceholder")]
        [Range(0,100)]
        public double Kcal { get; set; }
        public int? QuantityTypeId { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(ResourceType = typeof (Ingredient), Name = "Link", Prompt = "LinkPlaceholder")]
        public string Link { get; set; }
        [Display(ResourceType = typeof (Ingredient), Name = "Brand", Prompt = "BrandPlaceholder")]
        public int? BrandId { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
        public IEnumerable<QuantityTypeViewModel> Quantities { get; set; }
        public IEnumerable<RecipeViewModel> Recipes { get; set; }

        public IEnumerable<MealViewModel> Meals { get; set; }
    }
}