using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using asp_net_web_mvc_1.App_Start;

namespace asp_net_web_mvc_1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
