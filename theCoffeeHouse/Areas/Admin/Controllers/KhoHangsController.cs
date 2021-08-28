using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models;

namespace theCoffeeHouse.Areas.Admin.Controllers
{
    public class KhoHangsController : Controller
    {
        private TheCoffeeHouse db = new TheCoffeeHouse();

        // GET: Admin/KhoHangs
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            //Các biến sắp xếp
            ViewBag.SapXepTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.SapXepGia = sortOrder == "gia" ? "gia_desc" : "gia";
            //lấy giá trị bộ lọc hiện tại
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFillter = searchString;
            //lấy danh sách hàng
            var khoHangs = db.KhoHangs.Select(p => p);
            //lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                khoHangs = khoHangs.Where(p => p.tenSanPham.Contains(searchString));
            }
            //sắp xếp
            switch (sortOrder)
            {
                case "ten_desc":
                    khoHangs = khoHangs.OrderByDescending(s => s.tenSanPham);
                    break;
                case "gia":
                    khoHangs = khoHangs.OrderBy(s => s.giaNhap);
                    break;
                case "gia_desc":
                    khoHangs = khoHangs.OrderByDescending(s => s.giaNhap);
                    break;
                default:
                    khoHangs = khoHangs.OrderBy(s => s.tenSanPham);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(khoHangs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/KhoHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoHang khoHang = db.KhoHangs.Find(id);
            if (khoHang == null)
            {
                return HttpNotFound();
            }
            return View(khoHang);
        }

        // GET: Admin/KhoHangs/Create
        public ActionResult Create()
        {
            ViewBag.maSanPham = new SelectList(db.SanPhams, "maSanPham", "tenSanPham");
            return View();
        }

        // POST: Admin/KhoHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSanPham,tenSanPham,soLuongTon,giaNhap,ghiChu")] KhoHang khoHang)
        {
            if (ModelState.IsValid)
            {
                db.KhoHangs.Add(khoHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maSanPham = new SelectList(db.SanPhams, "maSanPham", "tenSanPham", khoHang.maSanPham);
            return View(khoHang);
        }

        // GET: Admin/KhoHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoHang khoHang = db.KhoHangs.Find(id);
            if (khoHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.maSanPham = new SelectList(db.SanPhams, "maSanPham", "tenSanPham", khoHang.maSanPham);
            return View(khoHang);
        }

        // POST: Admin/KhoHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSanPham,tenSanPham,soLuongTon,giaNhap,ghiChu")] KhoHang khoHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maSanPham = new SelectList(db.SanPhams, "maSanPham", "tenSanPham", khoHang.maSanPham);
            return View(khoHang);
        }

        // GET: Admin/KhoHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoHang khoHang = db.KhoHangs.Find(id);
            if (khoHang == null)
            {
                return HttpNotFound();
            }
            return View(khoHang);
        }

        // POST: Admin/KhoHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhoHang khoHang = db.KhoHangs.Find(id);
            db.KhoHangs.Remove(khoHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
