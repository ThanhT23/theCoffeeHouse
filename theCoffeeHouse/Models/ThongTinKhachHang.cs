namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinKhachHang")]
    public partial class ThongTinKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinKhachHang()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã khách hàng")]
        public int maKhachHang { get; set; }

        [StringLength(30)]
        [DisplayName("Tên đăng nhập")]
        public string tenDangNhap { get; set; }

        [StringLength(40)]
        [DisplayName("Tên khách hàng")]
        public string tenKhachHang { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? ngaySinh { get; set; }

        [DisplayName("Giới tính")]
        public bool? gioiTinh { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string soDienThoai { get; set; }

        [StringLength(30)]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Địa chỉ")]
        public string diaChi { get; set; }

        [StringLength(100)]
        [DisplayName("Ghi chú")]
        public string ghiChu { get; set; }

        [StringLength(100)]
        [DisplayName("Hình ảnh")]
        public string hinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
