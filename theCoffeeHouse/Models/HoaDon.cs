namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int maHoaDon { get; set; }

        public int? maKhachHang { get; set; }

        public DateTime? ngayBan { get; set; }

        public int? tongSoLuong { get; set; }

        public double? giamGia { get; set; }

        public double? thanhTien { get; set; }

        [StringLength(50)]
        public string hinhThucThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual ThongTinKhachHang ThongTinKhachHang { get; set; }
    }
}
