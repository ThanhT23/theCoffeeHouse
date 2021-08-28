namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            ThongTinAdmins = new HashSet<ThongTinAdmin>();
            ThongTinKhachHangs = new HashSet<ThongTinKhachHang>();
        }

        [Key]
        [StringLength(30)]
        public string tenDangNhap { get; set; }

        [Required]
        [StringLength(30)]
        public string matKhau { get; set; }

        [Required]
        [StringLength(20)]
        public string loai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinAdmin> ThongTinAdmins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinKhachHang> ThongTinKhachHangs { get; set; }
    }
}
