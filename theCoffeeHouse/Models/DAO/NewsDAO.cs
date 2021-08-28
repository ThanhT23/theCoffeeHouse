using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace theCoffeeHouse.Models.DAO
{
    public class NewsDAO
    {
        TheCoffeeHouse db = null;
        public NewsDAO()
        {
            db = new TheCoffeeHouse();
        }

        public IEnumerable<TinTuc> ListAll(int page, int pageSize)
        {
            return db.TinTucs.OrderBy(y => y.maTinTuc).ToPagedList(page, pageSize);
        }


        public TinTuc ViewDetail(int id)
        {
            return db.TinTucs.Find(id);
        }
        public TinTuc NewNew()
        {

            return db.TinTucs.OrderByDescending(y => y.ngayDang).First();
        }

        public IEnumerable<TinTuc> ListByName(string name, int page, int pageSize)
        {
            return db.TinTucs.Where(y => y.tieuDe.Contains(name)).OrderByDescending(y => y.ngayDang).ToPagedList(page, pageSize);
        }


    }
}