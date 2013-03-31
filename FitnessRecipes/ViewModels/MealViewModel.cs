using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using FitnessRecipes.Resources.Common;
using FitnessRecipes.Resources.Models;


namespace FitnessRecipes.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(Meal), Name = "Name", Prompt = "NamePlaceholder")]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Meal), Name = "ImgUrl", Prompt = "ImgUrlPlaceholder")]
        public string ImgUrl { get; set; }
        [Display(ResourceType = typeof(Meal), Name = "CategoryId", Prompt = "CategoryIdPlaceholder")]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        [Display(ResourceType = typeof(Meal), Name = "ImgUrl", Prompt = "ImgUrlPlaceholder")]
        public HttpPostedFileWrapper File { get; set; }
        public MealCategoryViewModel Category { get; set; }
        public RecipeViewModel Recipe { get; set; }
        public IEnumerable<MealIngredientViewModel> Ingredients { get; set; }
        public IEnumerable<DietViewModel> Diets { get; set; }
        [Display(ResourceType = typeof(Common), Name = "Protein", Prompt = "ProteinPlaceholder")]
        public double Protein { get; set; }
        [Display(ResourceType = typeof(Common), Name = "Carbs", Prompt = "CarbPlaceholder")]
        public double Carb { get; set; }
        [Display(ResourceType = typeof(Common), Name = "Fat", Prompt = "FatPlaceholder")]
        public double Fat { get; set; }
        [Display(ResourceType = typeof(Common), Name = "Kcal", Prompt = "KcalPlaceholder")]
        public double Kcal { get; set; }
    }
}