using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        CourseService _courseService = new CourseService(); 
        public ActionResult Index()
        {
            ViewBag.selectedMenu = "lienhe";
            ViewBag.course = _courseService.getAll();
            return View();
        }
    }
}