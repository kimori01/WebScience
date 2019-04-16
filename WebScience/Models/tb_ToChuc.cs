namespace WebScience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ToChuc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string IdMaLyLich { get; set; }

        [StringLength(250)]
        public string TenToChuc { get; set; }

        [StringLength(250)]
        public string TenNguoiLanhDao { get; set; }

        [StringLength(20)]
        public string DienThoaiLanhDao { get; set; }

        [StringLength(250)]
        public string DiaChiToChuc { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
