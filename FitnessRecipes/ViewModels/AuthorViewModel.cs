
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessRecipes.ViewModels
{
    public class AuthorViewModel
    {
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        public string Description { get; set; }
        public UserViewModel User { get; set; }
    }
}