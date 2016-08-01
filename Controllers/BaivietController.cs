using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class BaivietController : Controller
    {
        BaiVietService _baivietService = new BaiVietService();
        // GET: Baiviet
        public ActionResult Index(int? baivietid)
        {
            if (baivietid == null || !baivietid.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            BaiViet b = _baivietService.findById(baivietid.Value);
            if (b == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<BaiViet> allBaiviet = _baivietService.getAll();
            ViewBag.allbaiviet = allBaiviet;
            ViewBag.baiviet = b;
            return View();
        }
    }
}