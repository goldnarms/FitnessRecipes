using AdminPortal.BLL.Interfaces;
using FitnessRecipes.BLL.Services;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Helpers
{
    public static class SessionFacade
    {
        private static IFormsAuthentication _formsAuthentication;
        public static string UserKey = "userid";
        public static string CurrentDietKey = "currentDiet";
        public static IFormsAuthentication FormsAuthentication
        {
            private get { return _formsAuthentication ?? new FormsAuth(); }
            set { _formsAuthentication = value; }
        }
        public static User User
        {
            get
            {
                if (!AppHttpContext.Current.User.Identity.IsAuthenticated ||
                   (AppHttpContext.Current.Session[UserKey] == null))
                {
                    return null;
                }
                return (User)AppHttpContext.Current.Session[UserKey];
            }
            set { AppHttpContext.Current.Session[UserKey] = value; }
        }

        public static DietViewModel CurrentDiet
        {
            get { return (DietViewModel)AppHttpContext.Current.Session[CurrentDietKey]; }
            set { AppHttpContext.Current.Session[CurrentDietKey] = value; }
        }
    }
}