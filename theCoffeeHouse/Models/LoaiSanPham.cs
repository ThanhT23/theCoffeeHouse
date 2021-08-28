namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Không để trống mã")]
        public int maLoai { get; set; }

        [Column("loaiSanPham")]
        [StringLength(50)]
        [Required(ErrorMessage = "Không để trống tên")]
        public string loaiSanPham1 { get; set; }

        [StringLength(1000)]
        public string gioiThieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
