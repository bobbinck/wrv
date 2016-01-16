using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DTS.Helpers.Infrastructure.Logging;
using Newtonsoft.Json.Serialization;
using rv3.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace rv3
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected INLogger _logger;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var container = ContainerFactory();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // MVC
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container); // WebApi

            // JSON formatting
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Fix JSON.NET self referencing hell
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            _logger = DependencyResolver.Current.GetService<INLogger>();
            _logger.Info("Application is starting");

            //added for web api - return JSON instead of XML
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
        private static IContainer ContainerFactory()
        {
            // AutoFac
            var builder = new ContainerBuilder();

            // Register MVC and WebApi controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            // Register context
            builder.Register(c => new ApplicationDbContext()).InstancePerRequest();

            // Register logging and services
            builder.RegisterType<NLogger>().As<INLogger>().SingleInstance();

            // register repositories
            builder.RegisterType<GuestRepository>().As<IGuestRepository>().InstancePerRequest();

            //builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerHttpRequest();
            //builder.RegisterType<SnowEventRepository>().As<ISnowEventRepository>().InstancePerHttpRequest().InstancePerApiRequest();
            //builder.RegisterType<MaterialRepository>().As<IMaterialRepository>().InstancePerHttpRequest().InstancePerApiRequest();
            //builder.RegisterType<LosRepository>().As<ILosRepository>().InstancePerHttpRequest().InstancePerApiRequest();
            //builder.RegisterType<SnowEventsService>().As<ISnowEventsService>().InstancePerHttpRequest().InstancePerApiRequest();

            // Build container
            var container = builder.Build();
            return container;
        }
    }
}
