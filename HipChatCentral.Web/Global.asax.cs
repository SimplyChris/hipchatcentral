using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HipChatCentral.Domain.Interfaces;
using HipChatCentral.Domain.Registries;
using HipChatCentral.Domain.Services;
using HipChatCentral.Web.IoC;
using StructureMap;

namespace TBSSandBox
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            ObjectFactory.Configure(x=>
                                        {
                                            x.AddRegistry<DomainRegistry>();
                                            x.AddRegistry<HipChatCentralRegistry>();
                                        });
            DependencyResolver.SetResolver(new CustomDependencyResolver());
            var resolver = new CustomDependencyResolver();
            var logConfigurator = resolver.GetService<ILogConfigurator>();
            logConfigurator.Configure();

            var logger = resolver.GetService<ICustomLogger<MvcApplication>>();
            logger.DebugLog("Application has been initialized");
            string.Format("test 123");
        }
    }
}