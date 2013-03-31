using System;
using System.Web;

namespace FitnessRecipes.Helpers
{
    public static class AppHttpContext
    {
        public static HttpContextBase Current { get { return _getter(); } }

        public static void SetContext(Func<HttpContextBase> getter)
        {
            _getter = getter;
        }

        private static Func<HttpContextBase> _getter = () => new HttpContextWrapper(HttpContext.Current);
    }
}