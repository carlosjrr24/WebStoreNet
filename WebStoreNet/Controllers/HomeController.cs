﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Productos()
        {
            ViewBag.Title = "Productos Page";

            return View();
        }

        public ActionResult Prueba()
        {
            ViewBag.Title = "Productos Page";

            return View();
        }


    }
}
