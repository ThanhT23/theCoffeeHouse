using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using theCoffeeHouse.Models.DAO;

namespace theCoffeeHouse.Models.CLASS
{
    public class HoaDonDAO
    {
        TheCoffeeHouse db = null;
        public HoaDonDAO()
        {
            db = new TheCoffeeHouse();
        }
        public int Insert(HoaDon order)
        {
            db.HoaDons.Add(order);
            db.SaveChanges();
            return order.maHoaDon;
        }
        public List<HoaDon> getRecentByUserName(string username)
        {
            KhacHangDAO k = new KhacHangDAO();
            ThongTinKhachHang user = k.GetBytenDangNhap(username);
            return db.HoaDons.Where(s => s.maKhachHang == user.maKhachHang).ToList();
        }
    }
}