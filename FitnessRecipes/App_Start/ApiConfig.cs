using System.Web.Http;
using Newtonsoft.Json;

namespace FitnessRecipes
{
    public class ApiConfig
    {
        public static void ConfigureApi(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}