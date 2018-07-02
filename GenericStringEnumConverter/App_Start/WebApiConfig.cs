using GenericStringEnumConverter.Converter;
using GenericStringEnumConverter.Enumeraciones;
using System.Web.Http;

namespace GenericStringEnumConverter {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Serializador generico
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new GenericStringEnumConverter<Idioma>());

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
