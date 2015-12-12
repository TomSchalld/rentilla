using System.Web;
using System.Web.Optimization;

namespace Rentilla
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                    "~/Scripts/jquery-{version}.js",
                                    "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxForm").Include(
                        "~/Scripts/ajaxForm.js"));

            bundles.Add(new ScriptBundle("~/bundles/panelslider").Include(
                      "~/Scripts/jquery.slider.js"));

            bundles.Add(new ScriptBundle("~/bundles/konami").Include(
                      "~/Scripts/konami.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                      "~/Scripts/jquery.form.js"));

            bundles.Add(new ScriptBundle("~/bundles/summernote").Include(
                        "~/Scripts/summernote.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                        "~/Scripts/modalform.js"));

            bundles.Add(new ScriptBundle("~/bundles/design").Include(
                        "~/Scripts/thumbnail.js",
                        "~/Scripts/searchUserBook.js",
                        "~/Scripts/alertFade.js",
                        "~/Scripts/profilePopup.js"));
            // CSS : 

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.css",
                     "~/Content/hover.css"));

            bundles.Add(new StyleBundle("~/Content/summernote").Include(
                      "~/Content/summernote.css"));
        }
    }
}
