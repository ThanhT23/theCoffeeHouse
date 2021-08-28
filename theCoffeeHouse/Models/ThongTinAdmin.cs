namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinAdmin")]
    public partial class ThongTinAdmin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int maAdmin { get; set; }

        [StringLength(30)]
        public string tenDangNhap { get; set; }

        [Required]
        [StringLength(40)]
        public string tenAdmin { get; set; }

        public DateTime? ngaySinh { get; set; }

        public bool? gioiTinh { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        public int? sdt { get; set; }

        public DateTime ngayBatDau { get; set; }

        [StringLength(100)]
        public string hinhAnh { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
