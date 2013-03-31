namespace FitnessRecipes.DAL.Models
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly FitnessRecipiesEntities _fitnessRecipiesEntities;

        public DbContextFactory()
        {
            _fitnessRecipiesEntities = new FitnessRecipiesEntities();
        }

        public FitnessRecipiesEntities GetFitnessRecipeEntities()
        {
            return _fitnessRecipiesEntities;
        }
    }
}