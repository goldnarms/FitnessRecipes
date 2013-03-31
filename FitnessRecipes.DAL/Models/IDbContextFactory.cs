namespace FitnessRecipes.DAL.Models
{
    interface IDbContextFactory
    {
        FitnessRecipiesEntities GetFitnessRecipeEntities();
    }
}
