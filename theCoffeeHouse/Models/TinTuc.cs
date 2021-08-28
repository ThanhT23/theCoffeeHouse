namespace theCoffeeHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maTinTuc { get; set; }

        [Required]
        [StringLength(1000)]
        public string tieuDe { get; set; }

        [StringLength(3000)]
        public string noiDung { get; set; }

        [StringLength(30)]
        public string hinhAnh { get; set; }

        public DateTime? ngayDang { get; set; }
    }
}
