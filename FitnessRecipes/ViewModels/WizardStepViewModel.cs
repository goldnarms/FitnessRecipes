namespace FitnessRecipes.ViewModels
{
    public class WizardStepViewModel
    {
        public string LinkText { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool Selected { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
        public object RouteValues { get; set; }
    }
}