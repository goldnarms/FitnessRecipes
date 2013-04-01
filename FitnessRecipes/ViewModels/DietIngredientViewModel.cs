using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.ViewModels
{
    public class DietIngredientViewModel
    {
        public int DealId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public int QuantityTypeId { get; set; }
        public string Day { get; set; }
        public int Time { get; set; }
        public DietViewModel Diet { get; set; }
        public IngredientViewModel Ingredient { get; set; }
        public QuantityTypeViewModel QuantityType { get; set; }
        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Carb { get; set; }
        public double Fat { get; set; }
    }
}