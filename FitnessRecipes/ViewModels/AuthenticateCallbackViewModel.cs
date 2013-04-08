using System;
using WorldDomination.Web.Authentication;

namespace FitnessRecipes.ViewModels
{
    public class AuthenticateCallbackViewModel
    {
        public IAuthenticatedClient AuthenticatedClient { get; set; }
        public Exception Exception { get; set; }
    }
}