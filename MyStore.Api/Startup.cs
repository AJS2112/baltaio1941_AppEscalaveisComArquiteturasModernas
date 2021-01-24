using DomainNotificationHelper.Events;
using DomainNotificationHelper.Helpers.Mvc.Containers;
using Microsoft.Owin.Cors;
using MyStore.Api.Helpers;
using MyStore.CrossCutting;
using Newtonsoft.Json;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace MyStore.Api
{
    public class Startup
    {
        public void Configurarion(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();

            ConfigureDependencyInjection(config, container);
            ConfigureWebApi(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            DependencyRegister.Register(container);

            config.DependencyResolver = new UnityResolverHelper(container);
            DomainEvent.Container = new DomainEventsContainer(config.DependencyResolver);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    
        
    }
}