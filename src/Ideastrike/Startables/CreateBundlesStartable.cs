using System.Collections.Generic;
using System.Web.Optimization;
using Autofac;

namespace Ideastrike.Startables
{
    public class CreateBundlesStartable : IStartable
    {
        public void Start()
        {
            AddJavascriptBundle(
                "~/scripts/top",
                new[]
                    {
                        "~/Scripts/modernizr-2.5.3.js",
                        "~/Scripts/respond.min.js"
                    });

            AddCssBundle(
                "~/content/top",
                new[]
                    {
                        "~/Content/bootstrap.min.css",
                        "~/Content/media.css",
                        "~/Content/style.css",
                        "~/Content/ideastrike.css",
                        "~/Content/jquery.fancybox.css",
                        "~/Content/jquery.fileupload-ui.css"
                    });

            AddJavascriptBundle(
                "~/scripts/bottom",
                new[]
                    {
                        "~/Scripts/jquery-1.7.1.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.fancybox.pack.js",
                        "~/Scripts/jquery.contra.min.js",
                        "~/Scripts/showdown.js",
                        "~/Scripts/ideastrike.js",
                        "~/Scripts/bootstrap-alerts.js",
                        "~/Scripts/bootstrap-dropdown.js",
                        "~/Scripts/social.js",
                        "~/Scripts/mustache.js"
                    });

            AddJavascriptBundle(
                "~/scripts/home/home",
                new[]
                    {
                        "~/Views/Home/home.js"
                    });

            AddJavascriptBundle(
                "~/scripts/idea/index",
                new[]
                    {
                        "~/Views/Idea/Index.js"
                    });
        }

        private static void AddJavascriptBundle(string path, IEnumerable<string> files)
        {
            Bundle bundle = new Bundle(path, new JsMinify());
            foreach (var f in files)
                bundle.AddFile(f);
            AddBundle(bundle);
        }

        private static void AddCssBundle(string path, IEnumerable<string> files)
        {
            Bundle bundle = new Bundle(path, new CssMinify());
            foreach (var f in files)
                bundle.AddFile(f);
            AddBundle(bundle);
        }


        private static void AddBundle(Bundle bundle)
        {
            BundleTable.Bundles.Add(bundle);
        }
    }
}