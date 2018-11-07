using System.Web;
using System.Web.Optimization;

namespace annualsalarycalcBL
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/jquery/jquery.min.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bootstrap/js/bootstrap.min.js",
                      "~/Content/DataTables/datatables.min.js",
                      "~/Content/toastr/toastr.min.js",
                      "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/DataTables/datatables.min.css",
                      "~/Content/toastr/toastr.min.css",
                      "~/Content/site.css",
                      "~/Content/fontawesome-free/css/all.min.css"));
        }
    }
}
