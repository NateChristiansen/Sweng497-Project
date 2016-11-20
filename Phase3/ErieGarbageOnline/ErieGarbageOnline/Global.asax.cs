using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Database.SetInitializer(new CreateDatabaseIfNotExists<EGODatabase>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EGODatabase>());
        }
    }
}
