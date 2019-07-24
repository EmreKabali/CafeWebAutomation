using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            logger.Info($"Application Started{Dns.GetHostName()} ");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
