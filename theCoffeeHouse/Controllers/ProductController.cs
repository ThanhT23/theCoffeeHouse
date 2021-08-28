using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models.DAO;

namespace theCoffeeHouse.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int id)
        {
            //lay ra loai san pham
            var CategoryDao = new LoaiSanPhamDAO();
            ViewBag.CategoryProducts = CategoryDao.ListAll();

            if (id == 0)
            {
                //lay ra tat ca san pham
                var productDao = new SanPhamDAO();
                ViewBag.Products = productDao.ListProduct();
            }
            else
            {
                //lay ra tat ca san pham theo id (ma loai)
                var productCategory = new SanPhamDAO();
                ViewBag.Products = productCategory.ListByCategory(id);
            }

            return View();
        }

        //lay ra chi tiet san pham va san pham lien quan
        public ActionResult Detail(int id)
        {
            //lay ra chi tiet san pham dua theo ma
            var Detailproduct = new SanPhamDAO().ViewDetail(id);

            //lay ra san pham lien quan chi tiet san pham
            ViewBag.RelatedProducts = new SanPhamDAO().ListRelatedProducts(id);

            return View(Detailproduct);
        }

    }
}