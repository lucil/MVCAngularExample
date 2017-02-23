using System.Web;
using System.Web.Optimization;

namespace EURISTest
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/toastr.js",
                         "~/Scripts/angular.js",
                         "~/Scripts/angular-route.js",
                         "~/Scripts/angular-cookies.js",
                         "~/Scripts/angular-validator.js",
                         "~/Scripts/angular-base64.js",
                         "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                         "~/Scripts/loading-bar.js",
                         "~/Scripts/underscore.js",
                          "~/Scripts/checklist-model.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/layout/topBar.directive.js",
                "~/Scripts/spa/layout/sideBar.directive.js",
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",
                "~/Scripts/spa/directives/tooltip.directive.js",
                "~/Scripts/spa/products/productCtrl.js",
                "~/Scripts/spa/products/productAddCtrl.js",
                "~/Scripts/spa/products/productEditCtrl.js",
                "~/Scripts/spa/pricelists/pricelistCtrl.js",
                "~/Scripts/spa/pricelists/pricelistAddCtrl.js",
                "~/Scripts/spa/pricelists/pricelistEditCtrl.js",
                 "~/Scripts/spa/pricelists/pricelistProductsCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/content/css/site.css",
                   "~/content/css/bootstrap.css",
                   "~/content/css/bootstrap-theme.css",
                   "~/content/css/font-awesome.css",
                   "~/content/css/toastr.css",
                   "~/content/css/loading-bar.css"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}