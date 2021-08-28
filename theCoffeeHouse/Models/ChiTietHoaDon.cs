namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int maChiTietHoaDon { get; set; }

        public int? maSanPham { get; set; }

        public int? soLuong { get; set; }

        public double? donGia { get; set; }

        public int? maHoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
