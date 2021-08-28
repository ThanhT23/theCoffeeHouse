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
    public class HoaDonsController : Controller
    {
        private TheCoffeeHouse db = new TheCoffeeHouse();

        // GET: Admin/HoaDons
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            //Các biến sắp xếp
            ViewBag.SapXepMad = sortOrder == "mad" ? "mad_desc" : "mad";
            ViewBag.SapXepMak = sortOrder == "mak" ? "mak_desc" : "mak";
            ViewBag.SapXepTien = sortOrder == "tien" ? "tien_desc" : "tien";
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
            var hoaDons = db.HoaDons.Select(p => p);
            //lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                hoaDons = hoaDons.Where(p => p.maHoaDon.ToString().Contains(searchString));
            }
            //sắp xếp
            switch (sortOrder)
            {
                case "mad_desc":
                    hoaDons = hoaDons.OrderByDescending(s => s.maHoaDon);
                    break;
                case "mak":
                    hoaDons = hoaDons.OrderBy(s => s.maHoaDon);
                    break;
                case "mak_desc":
                    hoaDons = hoaDons.OrderByDescending(s => s.maKhachHang);
                    break;
                case "tien":
                    hoaDons = hoaDons.OrderBy(s => s.thanhTien);
                    break;
                case "tien_desc":
                    hoaDons = hoaDons.OrderByDescending(s => s.thanhTien);
                    break;
                default:
                    hoaDons = hoaDons.OrderBy(s => s.maKhachHang);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(hoaDons.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            List<ChiTietHoaDon> chitiethoadon = db.ChiTietHoaDons.Where(s => s.maHoaDon == id).ToList();
            ViewBag.ListCTHD = chitiethoadon;

            var masanpham = chitiethoadon[0].maSanPham;
            SanPham sanpham = db.SanPhams.Find(masanpham);
            ViewBag.SanPham = sanpham;
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.maKhachHang = new SelectList(db.ThongTinKhachHangs, "maKhachHang", "tenDangNhap");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maHoaDon,maKhachHang,ngayBan,tongSoLuong,giamGia,thanhTien,hinhThucThanhToan")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maKhachHang = new SelectList(db.ThongTinKhachHangs, "maKhachHang", "tenDangNhap", hoaDon.maKhachHang);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.maKhachHang = new SelectList(db.ThongTinKhachHangs, "maKhachHang", "tenDangNhap", hoaDon.maKhachHang);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maHoaDon,maKhachHang,ngayBan,tongSoLuong,giamGia,thanhTien,hinhThucThanhToan")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maKhachHang = new SelectList(db.ThongTinKhachHangs, "maKhachHang", "tenDangNhap", hoaDon.maKhachHang);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
