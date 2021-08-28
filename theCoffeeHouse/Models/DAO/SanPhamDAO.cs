using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
namespace theCoffeeHouse.Models.DAO
{
    public class SanPhamDAO
    {
        TheCoffeeHouse db = null;
        public SanPhamDAO()
        {
            db = new TheCoffeeHouse();
        }
        //lay ra san pham la hang moi va hang nong
        public List<SanPham> ListNewProduct(int top)
        {
            return db.SanPhams.Where(s => s.hangMoi == true).Where(s => s.hangNong == true).Take(top).ToList();
        }
        //lay ra tat ca san pham
        public List<SanPham> ListProduct()
        {
            return db.SanPhams.ToList();
        }

        public IEnumerable<SanPham> ListAll(int page, int pageSize)
        {
            return db.SanPhams.OrderBy(y => y.maSanPham).ToPagedList(page, pageSize);
        }

        public List<string> ListName(string keyword)
        {
            return db.SanPhams.Where(x => x.tenSanPham.Contains(keyword)).Select(x => x.tenSanPham).ToList();
        }
        //lay ra san pham theo ma loai san pham
        public List<SanPham> ListByCategory(int id)
        {
            return db.SanPhams.Where(s => s.maLoai == id).ToList();
        }


        public IEnumerable<SanPham> ListAllPaging(string searchString, int page, int pageSize)
        {
            
            return db.SanPhams.Where(x => x.tenSanPham.Contains(searchString)).OrderBy(x => x.maSanPham).ToPagedList(page, pageSize);
        }


        public void UpdateImages(long productId, string images)
        {
            var product = db.SanPhams.Find(productId);
            product.hinhAnh = images;
            db.SaveChanges();
        }
        //lay ra chi tiet san pham
        public SanPham ViewDetail(long id)
        {
            return db.SanPhams.Find(id);
        }

        //lay ra cac san pham lien quan (co cung maloai)
        public List<SanPham> ListRelatedProducts(int id)
        {
            // chi tiet 1 san pham
            var product = db.SanPhams.Find(id);
            //lay ra cac san pham co cung ma loai voi san pham chi tiet ben tren
            return db.SanPhams.Where(x => x.maLoai == product.maLoai).ToList();

        }
        public int CategoryRelatedProducts(int id)
        {
            // chi tiet 1 san pham
            var product = db.SanPhams.Find(id);
            //lay ra cac san pham co cung ma loai voi san pham chi tiet ben tren
            return (int)product.maLoai;

        }
    }
}

  