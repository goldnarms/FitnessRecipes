﻿using FitnessRecipes.DAL.Models;

namespace FitnessRecipes.BLL.Services
{
    public static class QuantityConverter
    {
        public static double ConvertTo100Grams(int quantityTypeId, int ingredientId = 1)
        {
            switch (quantityTypeId)
            {
                //gram
                case 1:
                    {
                        return 100;
                    }
                //ts
                case 3:
                    {
                        return 20;
                    }
                //dl
                case 5:
                    {
                        return 1.2;
                    }
                //l
                case 6:
                    {
                        return 0.12;
                    }
                //ml
                case 8:
                    {
                        return 120;
                    }
                //barneskje
                case 10:
                    {
                        return 9;
                    }
                case 12:
                    {
                        return 1;
                    }
                case 13:
                    {
                        return 480;
                    }
                case 14:
                    {
                        var context = new DbContextFactory().GetFitnessRecipeEntities();
                        var repository = new IngredientQuantityRepository(context);
                        return repository.GetConvertFactor(ingredientId, quantityTypeId);
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
