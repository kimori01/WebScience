using System.Web;
using System.Web.Optimization;

namespace WebScience
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"
                    ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jQueryLTE").Include(
                    "~/Content/bower_components/jquery/dist/jquery.min.js",
                    "~/Content/bower_components/jquery-ui/jquery-ui.min.js",
                    "~/Content/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js",
                    "~/Content/bower_components/jquery-knob/dist/jquery.knob.min.js",
                    "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                    "~/Content/bower_components/raphael/raphael.min.js",
                    "~/Content/bower_components/morris.js/morris.min.js",
                    "~/Content/bower_components/moment/min/moment.min.js",
                    "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                    "~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                    "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/Content/bower_components/fastclick/lib/fastclick.js",
                    "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                    "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                    "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                    "~/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                    "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                    "~/Content/dist/js/adminlte.min.js",
                    "~/Content/dist/js/pages/dashboard.js",
                    "~/Content/dist/js/science.js",
                    "~/Content/dist/js/demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/LTEcss").Include(
                    "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                    "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                    "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                    "~/Content/dist/css/AdminLTE.min.css",
                    "~/Content/dist/css/science.css",
                    "~/Content/dist/css/skins/_all-skins.min.css",
                    "~/Content/bower_components/morris.js/morris.css",
                    "~/Content/bower_components/jvectormap/jquery-jvectormap.css",
                    "~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                    "~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                    "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                    "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));
        }
    }
}
