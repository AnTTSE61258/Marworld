using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarworldNewWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "courseDetails",
               url: "Khoahoc/{courseId}",
               defaults: new { controller = "KhoaHoc", action = "CourseDetail" }
               );
            routes.MapRoute(
               name: "tailieuDetails",
               url: "tailieu/{tailieuId}",
               defaults: new { controller = "Tailieu", action = "tailieuDetail" }
               );
            routes.MapRoute(
               name: "baivietDetails",
               url: "Baiviet/{baivietId}",
               defaults: new { controller = "Baiviet", action = "Index" }
               );




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
          
        }
    }
}
