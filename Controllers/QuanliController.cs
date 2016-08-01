using MarworldNewWeb.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuanliController : Controller
    {
        StringConstantService _stringConstantService = new StringConstantService();
        CourseService _courseService = new CourseService();
        TeacherService _teacherService = new TeacherService();
        CamnhanService _camnhanService = new CamnhanService();
        BaiVietService _baiVietService = new BaiVietService();
        CustomImageService _customImageService = new CustomImageService();
        TailieuService _tailieuService = new TailieuService();
        TeacherInCourseService _teacherInCourseService = new TeacherInCourseService();
        // GET: Quanli
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CoHoiNgheNghiep()
        {
            ViewBag.text_cohoinghenghiep = _stringConstantService.getValue(SLIMCONFIG.text_cohoinghenghiep);
            return View();
        }

        public ActionResult Sukien()
        {
            ViewBag.text_sukiennoibat = _stringConstantService.getValue(SLIMCONFIG.text_sukiennoibat);
            return View();

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult saveSukiennoibat(String sukiennoibat)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.text_sukiennoibat, sukiennoibat);

            return RedirectToAction("Sukien");
        }

        public ActionResult Tailieu()
        {
            ViewBag.tailieux = _tailieuService.getAll();
            ViewBag.tailieutext = _stringConstantService.getValue(SLIMCONFIG.tailieu_text);

            ViewBag.selectedMenu = "tailieu";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult saveTaiLieu(String id, String name, String authorname,String company, String loimodau
            ,String gioithieuchung, HttpPostedFileBase file, HttpPostedFileBase imageFile,String noidung, HttpPostedFileBase authorFile,String category)
        {
            String error = "";
            bool isExist = false;
            int _preId = -1;
            String filePath = "";
            String imagePath = "";
            String authorPath = "";
            if (id == null || id.Equals(""))
            {
                _preId = -1;
            }
            else if (int.TryParse(id, out _preId) == false)
            {
                error += "Error: Không thể parse ID <br/>";
            }
            //
            isExist = _tailieuService.findById(_preId) != null ? true : false;
            if(file==null && isExist == false)
            {
                error += "Error: Không có file";
            }
            if (imageFile == null && isExist == false)
            {
                error += "Error: Không có hình ảnh";
            }
            if (authorFile == null && isExist == false)
            {
                error += "error: Không có hình tác giả";
            }
            if (file != null && file.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "TailieuFiles");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                file.SaveAs(newPath + "/" + file.FileName);
                filePath = "/Images/" + "TailieuFiles/" + file.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }

            if (imageFile != null && imageFile.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "TailieuImage");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                imageFile.SaveAs(newPath + "/" + imageFile.FileName);
                imagePath = "/Images/" + "TailieuImage/" + imageFile.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }
            if (authorFile != null && authorFile.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "AuthorImage");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                authorFile.SaveAs(newPath + "/" + authorFile.FileName);
                authorPath = "/Images/" + "AuthorImage/" + authorFile.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }

            TempData["tailieuError"] = error;
            if (error.Equals(""))
            {

                _tailieuService.addTailieu(_preId, name, authorname, company, loimodau, gioithieuchung, filePath, imagePath, noidung,category,authorPath);
            }

            //chua xong
            return RedirectToAction("Tailieu");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addTeacherToCourse(String courseId, String teacherId)
        {
            int _preCourseId = int.Parse(courseId);
            int _preTeacherId = int.Parse(teacherId);
            _teacherInCourseService.add(_preTeacherId, _preCourseId);
            return RedirectToAction("KhoaHoc");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult deleteTeacherFromCourse(String courseId, String teacherId)
        {
            int _preCourseId = int.Parse(courseId);
            int _preTeacherId = int.Parse(teacherId);
            _teacherInCourseService.deleteByTeacherInCourse(_preCourseId, _preTeacherId);
            return RedirectToAction("KhoaHoc");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult saveTailieuText(String tailieutext)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.tailieu_text,tailieutext);
            return RedirectToAction("tailieu");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult saveCohoinghenghiep(String giaotrinh)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.text_cohoinghenghiep, giaotrinh);
            return RedirectToAction("CoHoiNgheNghiep");
        }
        public ActionResult Giaotrinhchuyenbiet()
        {

            ViewBag.text_giaotrinhchuyenbiet = _stringConstantService.getValue(SLIMCONFIG.text_giaotrinhchuyenbiet) ;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult savecustomImage(String customImageId,String ImageCategory,HttpPostedFileBase file)
        {
            String error = "";
            bool isExist = false;
            int _preId = -1;
            String filePath = "";
            if (customImageId == null || customImageId.Equals(""))
            {
                _preId = -1;
            }
            else if (int.TryParse(customImageId, out _preId) == false)
            {
                error += "Error: Không thể parse Custom Image ID <br/>";
            }
            //
            isExist = _customImageService.findById(_preId) != null ? true : false;
           if(ImageCategory == null || ImageCategory.Equals(""))
            {
                error += "Error: Không có category cho hình ảnh";
            }

            if (file == null && isExist == false)
            {
                error += "Error: Không có file";
            }

            if (file != null && file.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "CustomImages");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                file.SaveAs(newPath + "/" + file.FileName);
                filePath = "/Images/" + "CustomImages/" + file.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }
            TempData["customImageError"] = error;
            if (error.Equals(""))
            {
                _customImageService.AddCustomImage(_preId, ImageCategory, filePath);
            }


            return RedirectToAction("camnhan");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult saveGiaotrinhchuyenbiet(String giaotrinh)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.text_giaotrinhchuyenbiet, giaotrinh);
            return RedirectToAction("Giaotrinhchuyenbiet");
        }

        public ActionResult BaiViet()
        {
            List<BaiViet> baiviets = _baiVietService.getAll();
            ViewBag.e = TempData["error"];
            ViewBag.allBaiViet = baiviets;
            return View();
        }

        public ActionResult daotaodoanhnghiep()
        {
            ViewBag.text_giaotrinhthuctien = _stringConstantService.getValue(SLIMCONFIG.text_giaotrinhthuctien);
            ViewBag.text_baitapungdung = _stringConstantService.getValue(SLIMCONFIG.text_baitapungdung);
            ViewBag.text_linhhoatsangtao = _stringConstantService.getValue(SLIMCONFIG.text_linhhoatsangtao);
            ViewBag.text_chuongtrinhdaotaodoanhnghiep = _stringConstantService.getValue(SLIMCONFIG.text_chuongtrinhdaotaodoanhnghiep);
            ViewBag.text_phantichkhaosat = _stringConstantService.getValue(SLIMCONFIG.text_phantichkhaosat);
            ViewBag.text_tuvangiaiphap = _stringConstantService.getValue(SLIMCONFIG.text_tuvangiaiphap);
            ViewBag.text_danhgiaketqua = _stringConstantService.getValue(SLIMCONFIG.text_danhgiaketqua);
            ViewBag.text_chuongtrinhtuvandoanhnghiep = _stringConstantService.getValue(SLIMCONFIG.text_chuongtrinhtuvandoanhnghiep);

            return View();
        }
        public ActionResult VeChungtoi()
        {
            ViewBag.text_vechungtoi = _stringConstantService.getValue(SLIMCONFIG.text_vechungtoi);
            ViewBag.text_taisaolaichon = _stringConstantService.getValue(SLIMCONFIG.text_taisaolaichon);
            ViewBag.text_tamnhinsumenh = _stringConstantService.getValue(SLIMCONFIG.text_tamnhinsumenh);

            return View();
        }

        public ActionResult Camnhan()
        {
            ViewBag.allCamnhan = _camnhanService.getAll();
            ViewBag.customImageError = TempData["customImageError"];
            List<CustomImage> allCustomImages = _customImageService.getAll();
            ViewBag.allCustomImages = allCustomImages;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addBaiViet(String id, String title, String description, HttpPostedFileBase file,String category
            , String detail)
        {
            String error = "";
            bool isExist = false;
            int _preId = -1;
            String filePath = "";
            if (id == null || id.Equals(""))
            {
                _preId = -1;
            }
            else if (int.TryParse(id, out _preId) == false)
            {
                error += "Error: Không thể parse BaiViet ID <br/>";
            }
            isExist = _baiVietService.findById(_preId) != null ? true : false;
            if (title == null || title.Equals(""))
            {
                error += "Error: Không có tên bài viết <br/>";
            }
            if (description == null || description.Equals(""))
            {
                error += "Error: Không có description cho bài viết <br/>";
            }
            if (detail == null || detail.Equals(""))
            {
                error += "Error: Không có detail cho bài viết <br/>";
            }
            if (category == null || category.Equals(""))
            {
                error += "Error: Không có category <br/>";
            }

            if (file == null && isExist == false)
            {
                error += "Error: Không có hình ảnh đại diện cho bài viết";
            }

            if (file != null && file.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "BaiVietImages");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                file.SaveAs(newPath + "/" + file.FileName);
                filePath = "/Images/" + "BaiVietImages/" + file.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }
            TempData["error"] = error;
            if (error.Equals(""))
            {
                _baiVietService.addBaiViet(_preId,title,filePath,description,category,detail);
            }



            return RedirectToAction("BaiViet");



        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult savecamnhan(String id, String name, String camnhan, String doituong)
        {
            String error = "";
            int _preid = -1;
            int.TryParse(id, out _preid);
            if (name == null || name.Equals(""))
            {
                error += "Error: Không có tên người cảm nhận";
            }
            if (camnhan == null || camnhan.Equals(""))
            {
                error += "Error: Không có cảm nhận";
            }
            if (doituong == null || doituong.Equals(""))
            {
                doituong += "Error: Không có đối tượng";
            }
            _camnhanService.addCamnhan(_preid, name, camnhan, doituong);
            return RedirectToAction("Camnhan");
            

        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult savedaotaodoanhnghiep(String giaotrinhthuctien,String baitapungdung, String linhhoatsangtao,
            String daotaodoanhnghiep, String phantichkhaosat, String tuvangiaiphap, String danhgiaketqua, String chuongtrinhtuvandoanhnghiep)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.text_giaotrinhthuctien,giaotrinhthuctien);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_baitapungdung, baitapungdung);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_linhhoatsangtao, linhhoatsangtao);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_chuongtrinhdaotaodoanhnghiep, daotaodoanhnghiep);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_phantichkhaosat, phantichkhaosat);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_tuvangiaiphap, tuvangiaiphap);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_danhgiaketqua, danhgiaketqua);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_chuongtrinhtuvandoanhnghiep, chuongtrinhtuvandoanhnghiep);


            return RedirectToAction("daotaodoanhnghiep");

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult saveVechungtoi(String vechungtoi, String taisaolaichon, String tamnhinsumenh)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.text_vechungtoi, vechungtoi);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_taisaolaichon, taisaolaichon);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_tamnhinsumenh, tamnhinsumenh);
            return RedirectToAction("VeChungToi");

        }
        public ActionResult TrangChu()
        {
            string trangchusliderPath = Server.MapPath(SLIMCONFIG.path + "TrangChuSlider");

             DirectoryInfo d = new DirectoryInfo(trangchusliderPath);//Assuming Test is your Folder
             if (!d.Exists)
            {
                System.IO.Directory.CreateDirectory(trangchusliderPath);
            }
            FileInfo[] Files = d.GetFiles();
            ViewBag.rootString = Server.MapPath("~");
            ViewBag.sliderFiles = Files;
            ViewBag.text_khampha = _stringConstantService.getValue(SLIMCONFIG.text_khampha);
            ViewBag.text_giangviengchuyengia = _stringConstantService.getValue(SLIMCONFIG.text_giangvienchuyengia);
            return View();
        }

        public ActionResult ChuyenGia()
        {
            List<Teacher> allTeachers = _teacherService.getAll();
            ViewBag.allTeachers = allTeachers;
            ViewBag.e = TempData["error"];

            return View();
        }

        public ActionResult KhoaHoc()
        {
            List<Course> allCourse = _courseService.getAll();
            ViewBag.allCourses = allCourse;
            ViewBag.e = TempData["error"];
            return View();
        }
        [HttpPost]
        public String SaveChangeTrangChu(String text_khampha, String text_giangvienchuyengia)
        {
            _stringConstantService.addStringConstant(SLIMCONFIG.text_khampha, text_khampha);
            _stringConstantService.addStringConstant(SLIMCONFIG.text_giangvienchuyengia, text_giangvienchuyengia);
            return "success";
        }
        [HttpPost]
        public ActionResult addTeacher(String id, String name, HttpPostedFileBase file, String congty, String caunoi, String gioithieu)
        {
            String error = "";
            bool isExist = false;
            int _preId = -1;
            String filePath = "";
            if (id==null || id.Equals(""))
            {
                _preId = -1;
            }
            else if (int.TryParse(id,out _preId)==false)
            {
                error += "Error: Không thể parse teacher ID <br/>";
            }
            isExist = _teacherService.findById(_preId) != null ? true : false;
            if(name == null || name.Equals(""))
            {
                error += "Error: Không có tên giảng viên <br/>";
            }
            if (file == null && isExist == false)
            {
                error += "Error: Không có hình ảnh giảng viên";
            }
            if(congty == null || congty.Equals(""))
            {
                error += "Error: Không có vị trí đang công tác";
            }
            if (file != null && file.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "TeacherImages");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                file.SaveAs(newPath + "/" + file.FileName);
                filePath = "/Images/" + "TeacherImages/" + file.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }
            TempData["error"] = error;
            if (error.Equals(""))
            {
                _teacherService.addTeacher(_preId, name, congty, filePath, caunoi, gioithieu);
            }

            return RedirectToAction("ChuyenGia");
        }
        [HttpGet]
        public Object getCourseObject(String id)
        {
            int _preId = -1;
            if(id == null || id.Equals(""))
            {
                return null;
            }
            if(int.TryParse(id,out _preId)==false)
            {
                return null;
            }
            return JsonConvert.SerializeObject(_courseService.findById(_preId));
        }

        [HttpGet]
        public Object AllCourse()
        {
            return JsonConvert.SerializeObject(_courseService.getAll());
        }
        [HttpGet]
        public Object AllTeacher()
        {
            return JsonConvert.SerializeObject(_teacherService.getAll());
        }
        [HttpGet]
        public Object AllCamnhan()
        {
            return JsonConvert.SerializeObject(_camnhanService.getAll());
        }
        [HttpGet]
        public Object AllBaiViet()
        {
            return JsonConvert.SerializeObject(_baiVietService.getAll());
        }
        [HttpGet]
        public Object AllTailieu()
        {
            return JsonConvert.SerializeObject(_tailieuService.getAll());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addKhoaHoc(String tenkhoahoc, String thoiluong, HttpPostedFileBase file, String lithuyet, String casestudy, String workshop, String diachihoc
           , String khaigiang, String hocphi, String thoigianhoc, String handangki, String noidung, String doituong, String ghichu, String gioithieu, bool isShowed = false)
        {
            int _prelithuyet =0;
            int _precasestudy =0;
            int _preworkshop =0 ;
            int _preThoiLuong =0 ;
            DateTime _preKhaiGiang = new DateTime();
            DateTime _preHanDangKi = new DateTime() ;
            double _prehocphi = 0 ;
            ViewBag.e = "";
            String filePath = "";

            if (tenkhoahoc == null || tenkhoahoc.Equals(""))
            {
                ViewBag.e += "Error: Không có tên khóa học<br/>";
            }
            Boolean isExist = _courseService.findByName(tenkhoahoc) == null ? false : true;
            if (file == null&&!isExist)
            {
                ViewBag.e += "Error:Không có hình ảnh khóa học<br/>";
            }

            if (lithuyet == null||lithuyet.Equals(""))
            {
                ViewBag.e += "Error: không có số tiết lí thuyết<br/>";
            }
            else
            {
                if (int.TryParse(lithuyet,out _prelithuyet)==false)
                {
                    ViewBag.e += "Error: Không thể parse lí thuyết<br/>";
                }
            }
            if (casestudy == null||casestudy.Equals(""))
            {
                ViewBag.e += "Error: không có số tiết case study<br/>";
            }
            else
            {
                if (int.TryParse(casestudy, out _precasestudy) == false)
                {
                    ViewBag.e += "Error: Không thể parse case study<br/>";
                }
            }
            if (workshop == null||workshop.Equals(""))
            {
                ViewBag.e += "Error: không có số tiết workshop<br/>";
            }
            else
            {
                if (int.TryParse(workshop, out _preworkshop) == false)
                {
                    ViewBag.e += "Error: Không thể parse workshop<br/>";
                }
            }
            if (diachihoc == null || diachihoc.Equals(""))
            {
                ViewBag.e += "Error: Không có địa chỉ học<br/>";
            }
            if (khaigiang == null || khaigiang.Equals(""))
            {
                ViewBag.e += "Error: Không có ngày khai giảng<br/>";
            }
            else if (DateTime.TryParseExact(khaigiang, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _preKhaiGiang) == false)
            {
                ViewBag.e += "Error: Error while parsing khai giang<br/>";
            }
            if (hocphi == null || hocphi.Equals(""))
            {
                ViewBag.e += "Error: không có học phí <br/>";
            }
            else
            {
                if (double.TryParse(hocphi,out _prehocphi) == false)
                {
                    ViewBag.e += "Error: Error while parsing học phí <br/>";
                }
            }
            if (thoigianhoc ==null || thoigianhoc.Equals(""))
            {
                ViewBag.e += "Error: Không có thời gian học <br/>";
            }

            if (handangki == null || handangki.Equals(""))
            {
                ViewBag.e += "Error: không có hạn đăng kí";
            }
            else if (DateTime.TryParseExact(handangki, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _preHanDangKi) == false)
            {
                ViewBag.e += "Error: error while parsing han dang ki";
            }
            if (thoiluong == null || thoiluong.Equals(""))
            {
                ViewBag.e += "Error: không có thời lượng";
            }else if (int.TryParse(thoiluong,out _preThoiLuong)==false)
            {
                ViewBag.e += "Error: Không thể parse thời lượng";
            }
            if (!"".Equals(ViewBag.e))
            {
                TempData["error"] = ViewBag.e;
                return RedirectToAction("KhoaHoc");
            }
            //Save file
            if (file != null && file.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "KhoaHocImages");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                file.SaveAs(newPath + "/" + file.FileName);
                filePath = "/Images/" + "KhoaHocImages/" + file.FileName;
            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }
            _courseService.addCourse(tenkhoahoc, filePath, _prelithuyet, _precasestudy, _preworkshop, diachihoc, _preThoiLuong, _preKhaiGiang, _prehocphi, thoigianhoc, _preHanDangKi, noidung, doituong,ghichu,gioithieu,isShowed);

            TempData["error"] = ViewBag.e;

            return RedirectToAction("KhoaHoc");
        }

        [HttpPost]
        public String DeleteCourse(String courseName)
        {
            Course c = _courseService.findByName(courseName);
            if (c == null)
            {
                return "Error: Không thể tìm thấy khóa học";
            }
            _courseService.deleteCourse(c);
            return "Success";
        }
        [HttpPost]
        public String DeleteBaiViet(String id)
        {
            int _preId = -1;
            if (id == null || id.Equals(""))
            {
                return "Error: ID Không hợp lệ";
            }
            else if (int.TryParse(id, out _preId) == false)
            {
                return "Error: lỗi khi parse id";
            }
            BaiViet b = _baiVietService.findById(_preId);
            if (b == null)
            {
                return "Error: Không thể tìm thấy bài viết";
            }
            _baiVietService.delete(b);
            return "success";
        }

        [HttpPost]
        public String DeleteComment(String id)
        {
            int _preId = -1;
            if (id == null || id.Equals(""))
            {
                return "Error: ID Không hợp lệ";
            }
            else if (int.TryParse(id, out _preId) == false)
            {
                return "Error: lỗi khi parse id";
            }
            Camnhan c = _camnhanService.findByid(_preId);
            if (c == null)
            {
                return "Error: Không thể tìm thấy comment";
            }
            _camnhanService.delete(c);
            return "success";

        }
        [HttpPost]
        public String deleteCustomImage(String id)
        {
            int _preId = -1;
            if (id == null || id.Equals(""))
            {
                return "Error: ID Không hợp lệ";
            }
            else if (int.TryParse(id, out _preId) == false)
            {
                return "Error: lỗi khi parse id";
            }
            CustomImage t = _customImageService.findById(_preId);
            if (t == null)
            {
                return "Error: Không thể tìm thấy Custom Image";
            }
            _customImageService.delete(t);
            return "Success";
        }

        [HttpPost]
        public String DeleteTeacher(String id)
        {
            int _preId = -1;
            if (id == null || id.Equals(""))
            {
                return "Error: ID Không hợp lệ";
            }
            else if(int.TryParse(id,out _preId) == false)
            {
                return "Error: lỗi khi parse id";
            }
            Teacher t = _teacherService.findById(_preId);
            if (t == null)
            {
                return "Error: Không thể tìm thấy giảng viên";
            }
            _teacherService.deteleTeacher(t);
            return "Success";
        }

        [HttpPost]
        public String deletetailieu(String id)
        {
            int _preId = -1;
            if (id == null || id.Equals(""))
            {
                return "Error: ID Không hợp lệ";
            }
            else if (int.TryParse(id, out _preId) == false)
            {
                return "Error: lỗi khi parse id";
            }
            Tailieu t = _tailieuService.findById(_preId);
            if (t == null)
            {
                return "Error: Không thể tìm thấy tài liệu";
            }
            _tailieuService.delete(t);
            return "Success";
        }

        [HttpPost]
        public String DeleteImage(String type, String name)
        {
            string path = null;
            if (type.Equals("sliderImage"))
            {
                path = Server.MapPath(SLIMCONFIG.path + "TrangChuSlider");
            }
            if (path == null)
            {
                return "Can't find path";
            }
            DirectoryInfo d = new DirectoryInfo(path);
            if (!d.Exists)
            {
                System.IO.Directory.CreateDirectory(path);
            }
            FileInfo[] files = d.GetFiles();
            foreach(var file in files)
            {
                if (file.Name.Equals(name))
                {
                    file.Delete();
                }
            }

            return "success";
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            ViewBag.Error = "";
            if (file != null && file.FileName != null)
            {
                string newPath = Server.MapPath(SLIMCONFIG.path + "TrangChuSlider");
                if (!Directory.Exists(newPath))
                {
                    System.IO.Directory.CreateDirectory(newPath);
                }
                file.SaveAs(newPath+"/"+file.FileName);

            }
            else
            {
                ViewBag.Error += "File name is not found <\br>";
            }


            return RedirectToAction("TrangChu");
        }
    }
}