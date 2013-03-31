using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessRecipes.ViewModels
{
    public class IngredientCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
