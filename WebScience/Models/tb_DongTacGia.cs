using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WebScience.Models
{
    public class tb_DongTacGia
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Đồng Tác Giả")]
        public string TenDongTacGia { get; set; }

        [StringLength(50)]
        public string IdMaLyLich { get; set; }

        [StringLength(50)]
        public string MaDeTai { get; set; }

        [StringLength(50)]
        public string IdMaDeTai { get; set; }

        [Column(TypeName = "smalldatetime")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? NgayThamGia { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }
    }
}