using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessRecipes.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public AuthorViewModel Author { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public string ImgUrl { get; set; }
        public string WebUrl { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public IEnumerable<DietViewModel> Diets { get; set; }
        public IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
}
