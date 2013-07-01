using System.Web.Mvc;
using FitnessRecipes.Helpers;

namespace FitnessRecipes.Binders
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var identity = controllerContext.HttpContext.User.Identity;
            if (identity.IsAuthenticated)
            {
                return SessionFacade.User;
            }
            return null;
        }
    }
}