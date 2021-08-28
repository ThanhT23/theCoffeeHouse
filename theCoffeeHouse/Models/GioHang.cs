namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int maGioHang { get; set; }

        public int? maKhachHang { get; set; }

        public DateTime? ngayBan { get; set; }

        public int? tongSoLuong { get; set; }

        public double? thanhTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual ThongTinKhachHang ThongTinKhachHang { get; set; }
    }
}
