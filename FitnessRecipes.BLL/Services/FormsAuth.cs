using System.Web.Security;
using AdminPortal.BLL.Interfaces;

namespace FitnessRecipes.BLL.Services
{
    public class FormsAuth : IFormsAuthentication
    {
        public void SetAuthCookie(string userName, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(userName, rememberMe);
        }

        public void RedirectToLoginPage()
        {
            FormsAuthentication.RedirectToLoginPage();
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
