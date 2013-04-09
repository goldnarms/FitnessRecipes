using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FitnessRecipes.App_Start;
using FitnessRecipes.Helpers;
using WebMatrix.WebData;
using WorldDomination.Web.Authentication.Mvc;

namespace FitnessRecipes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyConfig.SetUpDependencies();
            AreaRegistration.RegisterAllAreas();
            AuthConfig.RegisterAuth();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            WorldDominationRouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApiConfig.ConfigureApi(GlobalConfiguration.Configuration);
            //MiniProfilerPackage.PreStart();
            MapperConfig.ConfigureMapper();
            var razorViewEngine = new RazorViewEngine();
            razorViewEngine.ViewLocationCache = new TwoLevelViewCache(razorViewEngine.ViewLocationCache);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(razorViewEngine);
        }

        protected void Application_BeginRequest()
        {
        }

        protected void Application_EndRequest()
        {
        }
    }
}