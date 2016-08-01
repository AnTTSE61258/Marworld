using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class KhoaHocController : Controller
    {
        CourseService _courseService = new CourseService();
        TeacherService _teacherService = new TeacherService();
        TeacherInCourseService _teacherInCourseService = new TeacherInCourseService();
        // GET: KhoaHoc
        public ActionResult Index()
        {
            ViewBag.courses = _courseService.getAll();
            ViewBag.selectedMenu = "khoahoc";
            return View();
        }
        public ActionResult CourseDetail(String courseId)
        {
            int _preid = -1;
            if (courseId == null || courseId.Equals("") || (int.TryParse(courseId,out _preid)==false))
            {
                return RedirectToAction("Index");
            }
            Course c = _courseService.findById(_preid);
            if (c == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.allteachers = _teacherInCourseService.listTeacher(c.id);
            ViewBag.course = c;
            ViewBag.selectedMenu = "khoahoc";
            return View();
        }
    }
}