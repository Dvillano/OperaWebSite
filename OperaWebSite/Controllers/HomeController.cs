﻿using OperaWebSite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class HomeController : Controller
    {
        [MyFilterAction]

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}