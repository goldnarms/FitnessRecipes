using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FitnessRecipes.App_Start;
using WebMatrix.WebData;

namespace FitnessRecipes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyConfig.SetUpDependencies();
            WebSecurity.InitializeDatabaseConnection(
                connectionStringName: "DefaultConnection", userTableName: "User", userIdColumn: "Id", userNameColumn: "Username", autoCreateTables: true);
            //WebSecurity.InitializeDatabaseConnection(
            //    connectionStringName: "FitnessRecipiesEntities", userTableName: "User", userIdColumn: "Id", userNameColumn: "Username", autoCreateTables: true);
            AreaRegistration.RegisterAllAreas();
            AuthConfig.RegisterAuth();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApiConfig.ConfigureApi(GlobalConfiguration.Configuration);
            //MiniProfilerPackage.PreStart();
            MapperConfig.ConfigureMapper();
        }

        protected void Application_BeginRequest()
        {
        }

        protected void Application_EndRequest()
        {
        }
    }
}