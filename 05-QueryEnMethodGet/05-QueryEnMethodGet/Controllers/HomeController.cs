using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_QueryEnMethodGet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    bool esMiPrimeraVez = true;
        //    ViewData["esMiPrimeraVez"] = true;

        //    return View(esMiPrimeraVez);
        //}

        public ActionResult Index(bool? esMiPrimeraVez)
        {
            if(esMiPrimeraVez == null)
                ViewData["esMiPrimeraVez"] = true;
            else
                ViewData["esMiPrimeraVez"] = false;


            return View();
        }
    }
}