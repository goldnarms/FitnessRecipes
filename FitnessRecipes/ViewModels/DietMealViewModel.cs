namespace FitnessRecipes.ViewModels
{
    public class DietMealViewModel
    {
        public int DietId { get; set; }
        public int MealId { get; set; }
        public int Time { get; set; }
        public string Day { get; set; }

        public virtual DietViewModel Diet { get; set; }
        public virtual MealViewModel Meal { get; set; }
    }
}