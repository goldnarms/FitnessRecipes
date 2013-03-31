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
        public double Kcal
        {
            get { return Ingredient.Kcal * Quantity / QuantityConverter.ConvertTo100Grams(QuantityType.ID); }
        }
        public double Protein
        {
            get { return Ingredient.Protein * Quantity / QuantityConverter.ConvertTo100Grams(QuantityType.ID); }
        }
        public double Carb
        {
            get { return Ingredient.Carb * Quantity / QuantityConverter.ConvertTo100Grams(QuantityType.ID); }
        }
        public double Fat
        {
            get { return Ingredient.Fat * Quantity / QuantityConverter.ConvertTo100Grams(QuantityType.ID); }
        }
    }
}