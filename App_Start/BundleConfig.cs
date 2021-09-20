﻿using System.Web.Optimization;

namespace asp_net_web_mvc_1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Styles/css").Include(
                "~/node_modules/normalize.css/normalize.css",
                "~/node_modules/bulma/css/bulma.css"
                ));

            bundles.Add(new Bundle("~/Scripts/js").Include(
                "~/Scripts/site.js"
                ));

            //bundles.Add(new Bundle("~/Scripts/js").Include(
            //    "~/node_modules/bootstrap/dist/js/bootstrap.bundle.js"
            //    ));
        }
    }
}
