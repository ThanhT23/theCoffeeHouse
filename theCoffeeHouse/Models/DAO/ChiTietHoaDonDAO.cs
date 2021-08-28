using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theCoffeeHouse.Models.DAO
{
	public class ChiTietHoaDonDAO
	{
        TheCoffeeHouse db = null;
		public ChiTietHoaDonDAO()
        {
            db = new TheCoffeeHouse();
        }
        public bool Insert(ChiTietHoaDon detail)
        {
            try
            {
                db.ChiTietHoaDons.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
        public List<ChiTietHoaDon> getByMaHoaDon(int mahoadon)
        {
            return db.ChiTietHoaDons.Where(s => s.maHoaDon == mahoadon).ToList();
        }
    }
}