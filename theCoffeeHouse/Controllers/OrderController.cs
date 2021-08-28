using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models;
using theCoffeeHouse.Models.CLASS;
using theCoffeeHouse.Models.DAO;

namespace theCoffeeHouse.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            HoaDonDAO d = new HoaDonDAO();
            var listHoaDon = d.getRecentByUserName(Session["UserName"].ToString());

            return View(listHoaDon);

        }
    }
}