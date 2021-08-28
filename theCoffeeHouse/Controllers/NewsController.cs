using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models.DAO;
using PagedList;

namespace theCoffeeHouse.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index(int page = 1, int pagesize = 4)
        {
            var tin = new NewsDAO();
            var listnews =  tin.ListAll(page, pagesize);

            ViewBag.TopNew = new NewsDAO().NewNew();
            return View(listnews);
        }
        public ActionResult Detail(int maTinTuc)
        {
            //lay ra chi tiet san pham dua theo ma
            var Detailnew = new NewsDAO().ViewDetail(maTinTuc);


            return View(Detailnew);
        }
    }
}