using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theCoffeeHouse.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult cauchuyenthuonghieu()
        {
            return View();
        }
        public ActionResult cuahang()
        {
            return View();
        }
        public ActionResult hanhtrinh()
        {
            return View();
        }
    }
}