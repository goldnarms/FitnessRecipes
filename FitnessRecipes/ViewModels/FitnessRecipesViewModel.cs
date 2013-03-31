using System.Collections.Generic;

namespace FitnessRecipes.ViewModels
{
    public class FitnessRecipesViewModel
    {
        public string Note { get; set; }
        public string ImageUrl { get; set; }
        public string WebUrl { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public List<MealIngredientViewModel> Foods { get; set; }
    }
}