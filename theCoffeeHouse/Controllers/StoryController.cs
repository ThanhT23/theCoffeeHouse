using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theCoffeeHouse.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Store()
        {
            return View();
        }
    }
}