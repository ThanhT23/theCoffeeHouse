using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models;

namespace theCoffeeHouse.Controllers
{
    public class ThongTinKhachHangsController : Controller
    {
        private TheCoffeeHouse db = new TheCoffeeHouse();

        // GET: ThongTinKhachHangs
        public ActionResult Index()
        {
            var thongTinKhachHangs = db.ThongTinKhachHangs.Include(t => t.TaiKhoan);
            return View(thongTinKhachHangs.ToList());
        }

        // GET: ThongTinKhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            if (thongTinKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHangs/Create
        public ActionResult Create()
        {
            ViewBag.tenDangNhap = new SelectList(db.TaiKhoans, "tenDangNhap", "matKhau");
            return View();
        }

        // POST: ThongTinKhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maKhachHang,tenDangNhap,tenKhachHang,ngaySinh,gioiTinh,soDienThoai,email,diaChi,ghiChu,hinhAnh")] ThongTinKhachHang thongTinKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinKhachHangs.Add(thongTinKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tenDangNhap = new SelectList(db.TaiKhoans, "tenDangNhap", "matKhau", thongTinKhachHang.tenDangNhap);
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            if (thongTinKhachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.tenDangNhap = new SelectList(db.TaiKhoans, "tenDangNhap", "matKhau", thongTinKhachHang.tenDangNhap);
            return View(thongTinKhachHang);
        }

        // POST: ThongTinKhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maKhachHang,tenDangNhap,tenKhachHang,ngaySinh,gioiTinh,soDienThoai,email,diaChi,ghiChu,hinhAnh")] ThongTinKhachHang thongTinKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinKhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tenDangNhap = new SelectList(db.TaiKhoans, "tenDangNhap", "matKhau", thongTinKhachHang.tenDangNhap);
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            if (thongTinKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachHang);
        }

        // POST: ThongTinKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            db.ThongTinKhachHangs.Remove(thongTinKhachHang);
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
