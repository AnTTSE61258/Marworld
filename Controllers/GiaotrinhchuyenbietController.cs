using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class GiaotrinhchuyenbietController : Controller
    {
        StringConstantService _stringConstantService = new StringConstantService();
        CustomImageService _customImageService = new CustomImageService();
        // GET: Giaotrinhchuyenbiet
        public ActionResult Index()
        {
            ViewBag.text_giaotrinhchuyenbiet = _stringConstantService.getValue(SLIMCONFIG.text_giaotrinhchuyenbiet);
            ViewBag.headerImage = _customImageService.getAllCustomImageWithCategory(SLIMCONFIG.customImage_background);
            return View();
        }
    }
}