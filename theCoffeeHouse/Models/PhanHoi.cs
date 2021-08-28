namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [Key]
        public int maPH { get; set; }

        public int? maKhachHang { get; set; }

        public int? diem { get; set; }

        [StringLength(1000)]
        public string ghiChu { get; set; }

        public virtual ThongTinKhachHang ThongTinKhachHang { get; set; }
    }
}
