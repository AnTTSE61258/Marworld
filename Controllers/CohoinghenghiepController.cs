using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class CohoinghenghiepController : Controller
    {
        StringConstantService _stringConstantService = new StringConstantService();
        CustomImageService _customImageService = new CustomImageService();

        // GET: Cohoinghenghiep
        public ActionResult Index()
        {
            ViewBag.text_cohoinghenghiep = _stringConstantService.getValue(SLIMCONFIG.text_cohoinghenghiep);
            ViewBag.headerImage = _customImageService.getAllCustomImageWithCategory(SLIMCONFIG.customImage_background);

            return View();
        }
    }
}