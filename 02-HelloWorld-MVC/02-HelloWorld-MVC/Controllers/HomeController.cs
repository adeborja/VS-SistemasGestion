﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_HelloWorld_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return "Hello World! desde el HomeController";
            return View();
        }

        public ActionResult saludo()
        {
            return View();
        }
    }
}