using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class DaotaodoanhnghiepController : Controller
    {
        StringConstantService _stringConstantService = new StringConstantService();
        // GET: Daotaodoanhnghiep
        public ActionResult Index()
        {
            ViewBag.text_giaotrinhthuctien = _stringConstantService.getValue(SLIMCONFIG.text_giaotrinhthuctien);
            ViewBag.text_baitapungdung = _stringConstantService.getValue(SLIMCONFIG.text_baitapungdung);
            ViewBag.text_linhhoatsangtao = _stringConstantService.getValue(SLIMCONFIG.text_linhhoatsangtao);
            ViewBag.text_chuongtrinhdaotaodoanhnghiep = _stringConstantService.getValue(SLIMCONFIG.text_chuongtrinhdaotaodoanhnghiep);
            ViewBag.text_phantichkhaosat = _stringConstantService.getValue(SLIMCONFIG.text_phantichkhaosat);
            ViewBag.text_tuvangiaiphap = _stringConstantService.getValue(SLIMCONFIG.text_tuvangiaiphap);
            ViewBag.text_danhgiaketqua = _stringConstantService.getValue(SLIMCONFIG.text_danhgiaketqua);
            ViewBag.text_chuongtrinhtuvandoanhnghiep = _stringConstantService.getValue(SLIMCONFIG.text_chuongtrinhtuvandoanhnghiep);
            ViewBag.selectedMenu = "daotaodoanhnghiep";

            return View();
        }
    }
}