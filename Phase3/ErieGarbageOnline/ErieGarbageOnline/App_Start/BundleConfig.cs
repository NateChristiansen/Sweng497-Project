using System.Web.Optimization;

namespace ErieGarbageOnline
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/site").Include(
                        "~/Scripts/libraries/jquery/jquery-{version}.js",
                        "~/Scripts/libraries/bootstrap/bootstrap.js",
                        "~/Scripts/libraries/angular/angular.js"));

            bundles.Add(new StyleBundle("~/content/site").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}