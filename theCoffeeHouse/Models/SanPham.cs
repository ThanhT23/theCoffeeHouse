namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Không để trống mã")]
        public int maSanPham { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không để trống tên")]
        public string tenSanPham { get; set; }

        [StringLength(1000)]
        public string gioiThieu { get; set; }

        [StringLength(1000)]
        public string moTa { get; set; }

        [StringLength(1000)]
        public string gioiThieuChiTiet { get; set; }

        public double? donGia { get; set; }

        public bool? hangMoi { get; set; }

        public bool? hangNong { get; set; }

        public bool? hangSale { get; set; }

        [StringLength(100)]
        public string hinhAnh { get; set; }

        public int? maLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual KhoHang KhoHang { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
