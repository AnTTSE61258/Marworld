﻿using MarworldNewWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarworldNewWeb.Controllers
{
    public class LichKhaiGiangController : Controller
    {
        CourseService _courseService = new CourseService();
        // GET: LichKhaiGiang
        public ActionResult Index()
        {
            ViewBag.selectedMenu = "lichkhaigiang";
            ViewBag.courses = _courseService.getAll();
            return View();
        }
    }
}