using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Resources.Common;

namespace FitnessRecipes.ViewModels
{
    public class  DietViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Navn")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        [Display(Name = "Bildesti")]
        public string ImgUrl { get; set; }
        [Display(Name = "Web adresse")]
        [DataType(DataType.Url)]
        public string WebUrl { get; set; }
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [DisplayFormat(NullDisplayText = "0", DataFormatString = "{0:n1}", ApplyFormatInEditMode = true)]
        public double? Protein { get; set; }
        [DisplayFormat(NullDisplayText = "0", DataFormatString = "{0:n1}", ApplyFormatInEditMode = true)]
        public double? Carb { get; set; }
        [DisplayFormat(NullDisplayText = "0", DataFormatString = "{0:n1}", ApplyFormatInEditMode = true)]
        public double? Fat { get; set; }
        [DisplayFormat(NullDisplayText = "0", DataFormatString = "{0:n0}", ApplyFormatInEditMode = true)]
        public double? Kcal { get; set; }
        public int? AuthorId { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public DietCategoryViewModel Category { get; set; }
        public AuthorViewModel Author { get; set; }
        public IEnumerable<DietMealViewModel> Meals { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public IEnumerable<DietIngredientViewModel> Ingredients { get; set; }
    }
}
