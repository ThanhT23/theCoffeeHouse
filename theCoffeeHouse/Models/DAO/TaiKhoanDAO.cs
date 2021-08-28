using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theCoffeeHouse.Models.DAO
{
    public class TaiKhoanDAO
    {
        TheCoffeeHouse db = null;
        public TaiKhoanDAO()
        {
            db = new TheCoffeeHouse();
        }
        public TaiKhoan GetById(string userName)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.tenDangNhap == userName);
        }
        public int Login(string userName, string passWord)
        {
            
            var result = db.TaiKhoans.SingleOrDefault(x => x.tenDangNhap == userName);
            //ten dang nhap k ton tai
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.loai == "admin")//la admin, chuyen huong den admin page
                {
                    return 3;
                }
                else//ko phai admin, la user
                {
                    if (result.matKhau == passWord)
                        return 1;//mat khau, tai khoan ton tai => sesion
                    else
                        return -2;//mat khau sai hoac khong ton tai
                }
            }

        }


        public bool CheckUserName(string userName)
        {
            return db.TaiKhoans.Count(x => x.tenDangNhap == userName) > 0;
        }

        //public bool CheckEmail(string email)
        //{
        //    return db.TaiKhoans.Count(x => x. == email) > 0;
        //}
        public TaiKhoan ViewDetail(string tenDangNhap)
        {
            return db.TaiKhoans.Find(tenDangNhap);
        }
        public TaiKhoan AutoRegisterForGuest()
        {
            TaiKhoan guestuser = new TaiKhoan();
            string milisec = DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds.ToString(); ;
            guestuser.tenDangNhap = "guest" + milisec;
            guestuser.matKhau = "1";
            guestuser.loai = "user";

                db.TaiKhoans.Add(guestuser);
                db.SaveChanges();
                return guestuser;

        }

        public void Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
        }

    }
}