using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models.DAO;

namespace theCoffeeHouse.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new SanPhamDAO();
            ViewBag.NewProducts = productDao.ListNewProduct(8);


            return View();
        }
    }
}