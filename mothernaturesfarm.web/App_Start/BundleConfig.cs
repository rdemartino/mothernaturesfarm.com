﻿using System.Web;
using System.Web.Optimization;

namespace mothernaturesfarm.web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/styles/default").Include(
                "~/Content/Styles/foundation.css",
                "~/Content/Styles/style.css"));

            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/Content/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts/common").Include(
                "~/Content/Scripts/what-input.js",
                "~/Content/Scripts/foundation.js",
                "~/Content/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueryval").Include(
                        "~/Content/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/scripts/modernizr").Include(
                        "~/Content/Scripts/modernizr-*"));
           
        }
    }
}
