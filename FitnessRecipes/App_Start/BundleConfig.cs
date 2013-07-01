using System.Web.Optimization;

namespace FitnessRecipes
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                "~/Scripts/angular.js",
                "~/App/Services/AuthorService.js",
                "~/App/Services/DietService.js",
                "~/App/Services/MealService.js",
                "~/App/App.js",
                "~/App/Controllers/FrontPageController.js",
                "~/App/Controllers/MealController.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                "~/Scripts/foundation/foundation.js",
                "~/Scripts/foundation/foundation.orbit.js",
                "~/Scripts/foundation/foundation.section.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainpage").Include(
                        "~/Scripts/foundation.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                "~/Scripts/chosen.jquery.min"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
            "~/js/recipe.js",
            "~/js/category.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/custom.modernizr.js"
                        //"~/Scripts/modernizr-*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            "~/Scripts/knockout.js"));

            bundles.Add(new ScriptBundle("~/bundles/fitnessrecipes").Include(
                        "~/Scripts/fitnessrecipes.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/Site.css"
                        //"~/Content/themes/base/jquery.ui.base.css",
                        //"~/Content/themes/base/jquery.ui.core.css",
                        //"~/Content/themes/base/jquery.ui.resizable.css",
                        //"~/Content/themes/base/jquery.ui.selectable.css",
                        //"~/Content/themes/base/jquery.ui.accordion.css",
                        //"~/Content/themes/base/jquery.ui.autocomplete.css",
                        //"~/Content/themes/base/jquery.ui.button.css",
                        //"~/Content/themes/base/jquery.ui.dialog.css",
                        //"~/Content/themes/base/jquery.ui.slider.css",
                        //"~/Content/themes/base/jquery.ui.tabs.css",
                        //"~/Content/themes/base/jquery.ui.datepicker.css",
                        //"~/Content/themes/base/jquery.ui.progressbar.css",
                        //"~/Content/themes/base/jquery.qtip.css",
                        //"~/Content/themes/base/jquery.ui.theme.css",
                        //"~/Content/themes/base/responsive.css",
                        //"~/Content/themes/base/jquery.fancybox.css"
                        ));

            bundles.Add(new StyleBundle("~/Content/themes/chosen").Include(
                "~/Content/themes/chosen.css"));

            bundles.Add(new StyleBundle("~/Content/themes/foundation").Include(
                "~/Content/themes/base/foundation.css"));
        }
    }
}