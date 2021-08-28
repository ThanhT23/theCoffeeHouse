using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models.CLASS;

namespace theCoffeeHouse.Models.DAO
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.Login(model.tenDangNhap, model.matKhau);
                if (result == 1)
                {
                    var user = dao.GetById(model.tenDangNhap);
                    Session["UserName"] = user.tenDangNhap;
                    return RedirectToAction("Index", "Home");

                }
                else if (result == 3)
                {
                    return RedirectToAction("Index", "Login", new { area = "Admin" });
                }
                else if (result == 0)
                {

                    ModelState.AddModelError("tenDangNhap", "Tài khoản không tồn tại.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("matKhau", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Remove("UserName");
            return Redirect("/");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                if (dao.CheckUserName(model.tenDangNhap))
                {
                    ModelState.AddModelError("tenDangNhapExsits", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var taikhoan = new TaiKhoan();
                    taikhoan.tenDangNhap = model.tenDangNhap;
                    taikhoan.matKhau = model.matKhau;
                    taikhoan.loai = "user";

                    dao.Insert(taikhoan);
                    if (dao.GetById(taikhoan.tenDangNhap) != null)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        Session["UserName"] = dao.GetById(taikhoan.tenDangNhap).tenDangNhap;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("dangkyfailed", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }


    }
}