//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessRecipes.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public int MealId { get; set; }
        public string WebUrl { get; set; }
        public Nullable<int> UserId { get; set; }
        public bool IsDeleted { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual Meal Meal { get; set; }
        public virtual User User { get; set; }
    }
}
