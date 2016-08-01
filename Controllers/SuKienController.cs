using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarworldNewWeb.Service;

namespace MarworldNewWeb.Controllers
{
    public class SuKienController : Controller
    {
        BaiVietService _baivietService = new BaiVietService();
        StringConstantService _stringConstantService = new StringConstantService();
        // GET: SuKien
        public ActionResult Index()
        {
            List<BaiViet> allBaiviet = _baivietService.getAll();
            for (int i = allBaiviet.Count-1;i>=0;i--)
            {
                BaiViet b = allBaiviet.ElementAt(i);
                if (!SLIMCONFIG.category_sukien.Equals(b.category))
                {
                    allBaiviet.RemoveAt(i);
                }
            }
            ViewBag.text_sukien = _stringConstantService.getValue(SLIMCONFIG.text_sukiennoibat);
            ViewBag.allbaiviet = allBaiviet;
            ViewBag.selectedMenu = "Sukien";
            return View();
        }
    }
}