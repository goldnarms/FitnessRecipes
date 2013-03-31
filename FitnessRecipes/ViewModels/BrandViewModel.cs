using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessRecipes.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string Link { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}