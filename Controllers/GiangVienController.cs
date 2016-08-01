using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class GiangVienController : Controller
    {
        TeacherService _teacherService = new TeacherService();
        // GET: GiangVien
        public ActionResult Index(int? id)
        {
            if (id!=null && id.HasValue)
            {
                Teacher t = _teacherService.findById(id.Value);
                ViewBag.pointedTeacher = t;
            }

            List<Teacher> allTeachers = _teacherService.getAll();
            ViewBag.allTeachers = allTeachers;
            ViewBag.selectedMenu = "GiangVien";

            return View();
        }
    }
}