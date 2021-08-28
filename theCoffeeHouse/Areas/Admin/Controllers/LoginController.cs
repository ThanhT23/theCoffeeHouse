using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffeeHouse.Models.CLASS;
using theCoffeeHouse.Models.DAO;

namespace theCoffeeHouse.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.Login(model.tenDangNhap, model.matKhau);
                if (result == 3)
                {
                    var user = dao.GetById(model.tenDangNhap);
                    Session["UserName"] = user.tenDangNhap;
                    return RedirectToAction("Index", "Default");
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
    }
}