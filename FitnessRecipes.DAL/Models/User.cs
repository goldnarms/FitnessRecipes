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
    
    public partial class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Diets = new HashSet<Diet>();
            this.MealFavorites = new HashSet<Meal>();
            this.Recipes = new HashSet<Recipe>();
            this.UserDiets = new HashSet<UserDiet>();
            this.Meals = new HashSet<Meal>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public string ImgUrl { get; set; }
        public string WebUrl { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Nullable<int> Role { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual ICollection<Meal> MealFavorites { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<UserDiet> UserDiets { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
