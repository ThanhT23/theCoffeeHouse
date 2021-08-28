namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoHang")]
    public partial class KhoHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maSanPham { get; set; }

        [StringLength(50)]
        public string tenSanPham { get; set; }

        public int? soLuongTon { get; set; }

        public double? giaNhap { get; set; }

        [StringLength(1000)]
        public string ghiChu { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
