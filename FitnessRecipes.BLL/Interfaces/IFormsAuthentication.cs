using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.BLL.Interfaces
{
    public interface IFormsAuthentication
    {
        void SetAuthCookie(string userName, bool rememberMe);
        void RedirectToLoginPage();
        void SignOut();
    }
}
