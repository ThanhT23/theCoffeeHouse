using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffeeHouse.Models.CLASS
{
    public class RegisterModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string tenDangNhap { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string matKhau { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("matKhau", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmmatKhau { set; get; }

      
    }
}