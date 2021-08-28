using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models;
using theCoffeeHouse.Models.DAO;
using PagedList;

namespace theCoffeeHouse.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string type, string search, int page = 1)
        { //lay ra loai san pham
            var d = new SanPhamDAO();
            var n = new NewsDAO();

            int pageSize = 4;
            if (type == "sanpham")
            {

                var list = d.ListAllPaging(search, page, pageSize);
                ViewBag.Name = search;
                ViewBag.List = list;
                return View();
            }
            else//type == tin
            {

                var list = n.ListByName(search, page, pageSize);
                ViewBag.NewName = search;
                return View(list);
            }

        }



    }
}