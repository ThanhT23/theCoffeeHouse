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
    public class SanPhamsController : Controller
    {
        private TheCoffeeHouse db = new TheCoffeeHouse();

        // GET: Admin/SanPhams
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            //Các biến sắp xếp
            ViewBag.SapXepTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.SapXepGia = sortOrder == "gia" ? "gia_desc" : "gia";
            ViewBag.SapXepMa = sortOrder == "ma" ? "ma_desc" : "ma";
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
            var sanPhams = db.SanPhams.Select(p => p);
            //lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = sanPhams.Where(p => p.tenSanPham.Contains(searchString));
            }
            //sắp xếp
            switch (sortOrder)
            {
                case "ten_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.tenSanPham);
                    break;
                case "gia":
                    sanPhams = sanPhams.OrderBy(s => s.donGia);
                    break;
                case "gia_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.donGia);
                    break;
                case "ma":
                    sanPhams = sanPhams.OrderBy(s => s.maLoai);
                    break;
                case "ma_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.maLoai);
                    break;
                default:
                    sanPhams = sanPhams.OrderBy(s => s.tenSanPham);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.maSanPham = new SelectList(db.KhoHangs, "maSanPham", "tenSanPham");
            ViewBag.maLoai = new SelectList(db.LoaiSanPhams, "maLoai", "loaiSanPham1");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSanPham,tenSanPham,gioiThieu,moTa,gioiThieuChiTiet,donGia,hangMoi,hangNong,hangSale,hinhAnh,maLoai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maSanPham = new SelectList(db.KhoHangs, "maSanPham", "tenSanPham", sanPham.maSanPham);
            ViewBag.maLoai = new SelectList(db.LoaiSanPhams, "maLoai", "loaiSanPham1", sanPham.maLoai);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.maSanPham = new SelectList(db.KhoHangs, "maSanPham", "tenSanPham", sanPham.maSanPham);
            ViewBag.maLoai = new SelectList(db.LoaiSanPhams, "maLoai", "loaiSanPham1", sanPham.maLoai);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSanPham,tenSanPham,gioiThieu,moTa,gioiThieuChiTiet,donGia,hangMoi,hangNong,hangSale,hinhAnh,maLoai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maSanPham = new SelectList(db.KhoHangs, "maSanPham", "tenSanPham", sanPham.maSanPham);
            ViewBag.maLoai = new SelectList(db.LoaiSanPhams, "maLoai", "loaiSanPham1", sanPham.maLoai);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
