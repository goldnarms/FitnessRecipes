using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldDomination.Web.Authentication.Mvc;

namespace FitnessRecipes.Helpers
{
    public class CallbackProvider : IAuthenticationCallbackProvider
    {
        public ActionResult Process(HttpContextBase context, AuthenticateCallbackData model)
        {
            return new ViewResult
            {
                ViewName = "AuthenticateCallback",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}