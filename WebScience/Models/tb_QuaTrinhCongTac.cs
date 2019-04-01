namespace WebScience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_QuaTrinhCongTac
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaTaiKhoan { get; set; }

        [StringLength(50)]
        public string ThoiGian { get; set; }

        [StringLength(250)]
        public string ViTriCongTac { get; set; }

        [StringLength(250)]
        public string ToChucCongTac { get; set; }

        [StringLength(250)]
        public string DiaChiCongTac { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }
    }
}
