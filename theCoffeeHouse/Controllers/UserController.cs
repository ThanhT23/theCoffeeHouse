using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models;
using theCoffeeHouse.Models.DAO;

namespace theCoffeeHouse.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string tenKhachHang, string ngaySinh, string gioiTinh, string soDienThoai, string email, string province, string diaChi, string ghiChu, string hinhAnh)
        {
            //tao thong tin khach hang cho guest
            ThongTinKhachHang guestinfo = new ThongTinKhachHang();
            var k = new KhacHangDAO();
            var exsits = k.GetBytenDangNhap(Session["UserName"].ToString());
            if (exsits != null)// tai khoan nay da co profile => update profile
            {
                //tao khahch hang moi co cung ma voi khach hang vua lay trong csdl 
                guestinfo.maKhachHang = exsits.maKhachHang;
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
                guestinfo.email = email;
                guestinfo.diaChi = diaChi + "/" + province;
                guestinfo.ghiChu = ghiChu;
                guestinfo.hinhAnh = hinhAnh;

                //update khach hang ms
                var result = k.Update(guestinfo);//update thong tin khach hang

                    
            }
            else//chua co profile => them 1 lan duy nhat
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
                guestinfo.email = email;
                guestinfo.diaChi = diaChi + "/" + province;
                guestinfo.ghiChu = ghiChu;
                guestinfo.hinhAnh = hinhAnh;

                //insert khach hang ms
                int e = k.Insert(guestinfo);//lay ra ma khach hang vua them
            }
           
            return View();
        }




    }
}