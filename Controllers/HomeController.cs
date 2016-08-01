using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class HomeController : Controller
    {
        StringConstantService _stringConstantService = new StringConstantService();
        CourseService _courseService = new CourseService();
        TeacherService _teacherService = new TeacherService();
        CamnhanService _camnhanService = new CamnhanService();
        BaiVietService _baivietService = new BaiVietService();
        CustomImageService _customService = new CustomImageService();
        public ActionResult GiangVien()
        {
            List<Teacher> allTeachers = _teacherService.getAll();
            ViewBag.allTeachers = allTeachers;
            return View();
        }
        public ActionResult Index()
        {
            string trangchusliderPath = Server.MapPath(SLIMCONFIG.path + "TrangChuSlider");

            DirectoryInfo d = new DirectoryInfo(trangchusliderPath);//Assuming Test is your Folder
            if (!d.Exists)
            {
                System.IO.Directory.CreateDirectory(trangchusliderPath);
            }
            FileInfo[] Files = d.GetFiles();
            ViewBag.rootString = Server.MapPath("~");
            ViewBag.sliderFiles = Files; //sliderfiles 1
            ViewBag.text_khampha = _stringConstantService.getValue(SLIMCONFIG.text_khampha);
            ViewBag.text_giangvienchuyengia = _stringConstantService.getValue(SLIMCONFIG.text_giangvienchuyengia);
            List<Course> allCourse = _courseService.getAll();
            List<Teacher> allTeaches = _teacherService.getRandom();
            List<Camnhan> allComments = _camnhanService.getAll();
            List<BaiViet> allBaiViets = _baivietService.getAll();
            List<Course> allShowedCourse = _courseService.getShowedCourse();
            List<CustomImage> camnhanImages = _customService.getAllCustomImageWithCategory(SLIMCONFIG.customImage_category_camnhan);
            ViewBag.allTeachers = allTeaches;
            ViewBag.allCourses = allCourse;
            ViewBag.allComments = allComments;
            ViewBag.allBaiViets = allBaiViets;
            ViewBag.camnhanImages = camnhanImages;
            ViewBag.showedCourse = allShowedCourse;
            ViewBag.selectedMenu = "Trangchu";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}