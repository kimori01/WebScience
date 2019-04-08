using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebScience.Models
{
    public class tb_GiaiThuong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập mã giải thưởng")]
        [Display(Name = "Mã Giải Thưởng")]
        public string MaGiaiThuong { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên giải thưởng")]
        [Display(Name = "Tên Giải Thưởng")]
        public string TenGiaiThuong { get; set; }

        [StringLength(50)]
        public string IdMaLyLich { get; set; }

        [StringLength(50)]
        public string HinhThuc { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string NamTangThuong { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }


    }
}