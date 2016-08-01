using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class AboutController : Controller
    {
        StringConstantService _stringConstantService = new StringConstantService();
        TeacherService _teacherService = new TeacherService();
        CustomImageService _customeImageService = new CustomImageService();
        // GET: About
        public ActionResult Index()
        {
            ViewBag.text_vechungtoi = _stringConstantService.getValue(SLIMCONFIG.text_vechungtoi);
            ViewBag.text_taisaolaichon = _stringConstantService.getValue(SLIMCONFIG.text_taisaolaichon);
            ViewBag.text_tamnhinsumenh = _stringConstantService.getValue(SLIMCONFIG.text_tamnhinsumenh);
            List<Teacher> allTeachers = _teacherService.getAll();
            ViewBag.allTeachers = allTeachers;
            ViewBag.headerImage = _customeImageService.getAllCustomImageWithCategory(SLIMCONFIG.customImage_background);

            ViewBag.selectedMenu = "About";

            return View();
        }
    }
}