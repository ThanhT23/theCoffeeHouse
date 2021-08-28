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
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {
            int id;
            if (TempData["id"] != null)
            {
                id = Int32.Parse(TempData["id"].ToString());
            }
            else
            {
                id = 1;
            }

            //lay ra san pham lien quan chi tiet san pham
            ViewBag.RelatedProducts = new SanPhamDAO().ListRelatedProducts(id);

            ViewBag.NewProducts = new SanPhamDAO().ListNewProduct(7);

            //lay ra session tu list
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

                int result = 0;
                foreach (var item in list)
                {
                    result = result + item.Quantity * (int)item.Product.donGia;
                }
                ViewBag.Total = result;
                ViewBag.Ship = 25000;
                ViewBag.TotalPrice = result + 25000 - 10000;

            }

            return View(list);
        }

        public ActionResult AddItem(int productId, int quantity)
        {
                var product = new SanPhamDAO().ViewDetail(productId);
                var cart = Session[CartSession];
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    //neu trong list ton tai san pham co ma nhap vao
                    if (list.Exists(x => x.Product.maSanPham == productId))
                    {

                        foreach (var item in list)
                        {
                            if (item.Product.maSanPham == productId)
                            {
                                item.Quantity += quantity;//them so luong san pham da co
                            }
                        }
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = quantity;
                        list.Add(item);
                    }
                    //Gán lại list vào session
                    Session[CartSession] = list;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    var list = new List<CartItem>();
                    //gán vào list
                    list.Add(item);
                    //Gán lại list vào session
                    Session[CartSession] = list;
                }
                //lay ra san pham vua them vao trong list
            TempData["id"] = productId;
            return RedirectToAction("Index");
        }
        public ActionResult QuickAddItem(int productId, int quantity)
        {

                var product = new SanPhamDAO().ViewDetail(productId);
                var cart = Session[CartSession];
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    //neu trong list ton tai san pham co ma nhap vao
                    if (list.Exists(x => x.Product.maSanPham == productId))
                    {

                        foreach (var item in list)
                        {
                            if (item.Product.maSanPham == productId)
                            {
                                item.Quantity += quantity;//them so luong san pham da co
                            }
                        }
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = quantity;
                        list.Add(item);
                    }
                    //Gán lại list vào session
                    Session[CartSession] = list;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    var list = new List<CartItem>();
                    //gán vào list
                    list.Add(item);
                    //Gán lại list vào session
                    Session[CartSession] = list;
                }
                //lay ra san pham vua them vao trong list

            TempData["id"] = productId;
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Redirect(url);
        }

        public ActionResult Delete(int delId)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.maSanPham == delId);
            Session[CartSession] = sessionCart;
            TempData["id"] = delId;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Paid()
        {

            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {

                list = (List<CartItem>)cart;
                int result = 0;
                foreach (var item in list)
                {
                    result = result + item.Quantity * (int)item.Product.donGia;
                }
                ViewBag.Total = result;
                ViewBag.Ship = 25000;
                ViewBag.TotalPrice = result + 25000;

            }
            //tao thong tin khach hang cho guest
            ThongTinKhachHang guestinfo = new ThongTinKhachHang();
            KhacHangDAO k = new KhacHangDAO();
            //lay ra thong tin user da dang nhap
            if(Session["UserName"] != null)
            {
                if (k.GetBytenDangNhap(Session["UserName"].ToString()) != null)// dang nhap roi va da co thong tin ca nhan
                {
                    guestinfo = k.GetBytenDangNhap(Session["UserName"].ToString());//lay ra thong tin user da co

                }
            }
            ViewBag.UserData = guestinfo;
            return View(list);


        }

        public ActionResult Paid(string tenKhachHang, string ngaySinh, string gioiTinh, string soDienThoai, string province, string diaChi, string ghiChu, string hinhThucThanhToan)
        {
            //tao thong tin khach hang cho guest
            ThongTinKhachHang guestinfo = new ThongTinKhachHang();

            KhacHangDAO k = new KhacHangDAO();

            //tao hoa don
            HoaDon hoadon = new HoaDon();
            hoadon.ngayBan = DateTime.Now;
            hoadon.giamGia = 10000;

            hoadon.hinhThucThanhToan = hinhThucThanhToan;

            //kiem tra xem da dang nhap hay chua

            if (Session["UserName"] == null) //chua dang nhap=> insert du lieu cho guest infor => insert vao hoa don
            {
                guestinfo.tenDangNhap = new TaiKhoanDAO().AutoRegisterForGuest().tenDangNhap; //auto dang ky cho guest (chua dang nhap)
                guestinfo.tenKhachHang = tenKhachHang;
                guestinfo.ngaySinh = DateTime.Parse(ngaySinh);
                if (gioiTinh == "Nam")
                {
                    guestinfo.gioiTinh = true;
                }
                else
                {
                    guestinfo.gioiTinh = false;
                }
                guestinfo.soDienThoai = soDienThoai;
                guestinfo.email = "xxxx";
                guestinfo.diaChi = diaChi + "/" + province;
                guestinfo.ghiChu = ghiChu;
                guestinfo.hinhAnh = "xxxx";

                hoadon.maKhachHang = k.Insert(guestinfo);//insert khach hang vao bang khach hang ,lay ra ma khach hang vua them
            }
            else if( k.GetBytenDangNhap(Session["UserName"].ToString()) != null)// dang nhap roi va da co thong tin ca nhan
            {

                guestinfo = k.GetBytenDangNhap(Session["UserName"].ToString());
                hoadon.maKhachHang = guestinfo.maKhachHang; //lay ra ma khach hang tu khach hang da co thong tin

            }
            else //dang nhap roi nhung chua co thong tin ca nhan => insert thong tin 1 lan
            {
                guestinfo.tenDangNhap = Session["UserName"].ToString();
                guestinfo.tenKhachHang = tenKhachHang;
                guestinfo.ngaySinh = DateTime.Parse(ngaySinh);

                if (gioiTinh == "Nam")
                {
                    guestinfo.gioiTinh = true;
                }
                else
                {
                    guestinfo.gioiTinh = false;
                }
                guestinfo.soDienThoai = soDienThoai;
                guestinfo.email = "xxxx";
                guestinfo.diaChi = diaChi + "/" + province;
                guestinfo.ghiChu = ghiChu;
                guestinfo.hinhAnh = "xxxx";

                hoadon.maKhachHang = k.Insert(guestinfo);//lay ra ma khach hang vua them
                
            }

            //insert khach hang ms
            //lay ra ds san pham luu cart trong session
            var list = (List<CartItem>)Session[CartSession];
            int result = 0;
            foreach (var item in list)
            {
                result = result + item.Quantity * (int)item.Product.donGia;//tinh tong tien
            }

            //them not cho hoa don
            hoadon.tongSoLuong = list.Count;
            hoadon.thanhTien = result + 25000;


            HoaDonDAO h = new HoaDonDAO();
            var mahd = h.Insert(hoadon);

            ChiTietHoaDonDAO detailDao = new ChiTietHoaDonDAO();
            //them nhieu chi tiet hoa don trong 1 hoa don
            foreach (var item in list)
            {
                var orderDetail = new ChiTietHoaDon();
                orderDetail.maSanPham = item.Product.maSanPham;
                orderDetail.soLuong = item.Quantity;
                orderDetail.donGia = item.Product.donGia;
                orderDetail.maHoaDon = mahd;//lay ra ma hoa don vua them
                detailDao.Insert(orderDetail);
            }
            return RedirectToAction("Index", "Success");
        }
    }
}