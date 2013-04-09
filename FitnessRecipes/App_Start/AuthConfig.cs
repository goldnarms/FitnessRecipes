using Microsoft.Web.WebPages.OAuth;

namespace FitnessRecipes
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
