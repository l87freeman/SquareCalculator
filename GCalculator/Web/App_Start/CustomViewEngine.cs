using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class CustomViewEngine: RazorViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new[] {
                "~/Views/Home/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Templates/{0}.cshtml",
            };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }

    public static class ViewConfig
    {
        public static void Configure()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());
        }
    }
}