using System.Collections.Generic;
using System.Linq;

namespace FitnessRecipes.ViewModels
{
    public class FrontPageViewModel
    {
        public List<RecipeViewModel> Recipes { get; set; }
        public List<DietViewModel> Diets { get; set; }
        public List<AuthorViewModel> Authors { get; set; }

    }
}