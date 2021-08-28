using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theCoffeeHouse.Models.DAO
{
    public class LoaiSanPhamDAO
    {
        TheCoffeeHouse db = null;
        public LoaiSanPhamDAO()
        {
            db = new TheCoffeeHouse();
        }
        //lay ra tat ca loai san pham
        public List<LoaiSanPham> ListAll()
        {
            return db.LoaiSanPhams.ToList();
        }

        //public LoaiSanPham ViewDetail(long id)
        //{
        //    return db.LoaiSanPham.Find(id);
        //}
    }
}
