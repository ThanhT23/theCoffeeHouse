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
    public class LoaiSanPhamsController : Controller
    {
        private TheCoffeeHouse db = new TheCoffeeHouse();

        // GET: Admin/LoaiSanPhams
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            //Các biến sắp xếp
            ViewBag.SapXepTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
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
            var loaiSanPhams = db.LoaiSanPhams.Select(p => p);
            //lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                loaiSanPhams = loaiSanPhams.Where(p => p.loaiSanPham1.Contains(searchString));
            }
            //sắp xếp
            switch (sortOrder)
            {
                case "ten_desc":
                    loaiSanPhams = loaiSanPhams.OrderByDescending(s => s.loaiSanPham1);
                    break;
                default:
                    loaiSanPhams = loaiSanPhams.OrderBy(s => s.loaiSanPham1);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(loaiSanPhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/LoaiSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maLoai,loaiSanPham1,gioiThieu")] LoaiSanPham loaiSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LoaiSanPhams.Add(loaiSanPham);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi Tạo Dữ Liệu " + ex.Message;
                return View(loaiSanPham);
            }
        }

        // GET: Admin/LoaiSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maLoai,loaiSanPham1,gioiThieu")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            try
            {
                db.LoaiSanPhams.Remove(loaiSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Không xóa được bản ghi này " + ex.Message;
                return View("Delete", loaiSanPham);
    }
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
