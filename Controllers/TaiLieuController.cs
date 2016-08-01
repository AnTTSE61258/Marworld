using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    [Authorize]
    public class TaiLieuController : Controller
    {
        TailieuService tailieuService = new TailieuService();
        StringConstantService stringConstantService = new StringConstantService();
        public ActionResult Index(String cat)

        {
            ViewBag.tailieutext = stringConstantService.getValue(SLIMCONFIG.tailieu_text);
            List<Tailieu> tailieux = tailieuService.getAll();
            if(cat!=null && !cat.Equals(""))
            {
                String category = "";
                if (cat.Equals("thuonghieu"))
                {
                    category = SLIMCONFIG.tailieu_category_thuonghieu;
                }
                if (cat.Equals("marketing"))
                {
                    category = SLIMCONFIG.tailieu_category_marketing;
                }
                if (!category.Equals(""))
                {
                    for(int i = tailieux.Count - 1; i >= 0; i--)
                    {
                        if (!category.Equals(tailieux.ElementAt(i).category))
                        {
                            tailieux.RemoveAt(i);
                        }
                    }
                }
            }
            ViewBag.tailieux = tailieux;
            ViewBag.selectedMenu = "tailieu";
            return View();
        }
        public ActionResult tailieuDetail(String tailieuId)
        {
            int _preid = -1;
            if (tailieuId == null || tailieuId.Equals("") || (int.TryParse(tailieuId, out _preid) == false))
            {
                return RedirectToAction("Index");
            }
            Tailieu t = tailieuService.findById(_preid);
            if (t == null)
            {
                return RedirectToAction("Index");
            }
           
            ViewBag.tailieu = t;
            ViewBag.tailieutext = stringConstantService.getValue(SLIMCONFIG.tailieu_text);

            ViewBag.selectedMenu = "tailieu";
            return View();
        }
    }
}