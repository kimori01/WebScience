namespace WebScience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_QuaTrinhDaoTao
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IdMaLyLich { get; set; }

        [StringLength(20)]
        public string MaBacDaoTao { get; set; }

        [StringLength(250)]
        public string NoiDaoTao { get; set; }

        [StringLength(250)]
        public string ChuyenMon { get; set; }

        [StringLength(20)]
        public string NamTotNghiep { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
