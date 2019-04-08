using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebScience.Models
{
    public class tb_VanBang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập mã văn bằng")]
        [Display(Name = "Mã Văn Bằng")]
        public string MaVanBang { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên văn bằng")]
        [Display(Name = "Tên Văn Bằng")]
        public string TenVanBang { get; set; }

        [StringLength(50)]
        public string IdMaLyLich { get; set; }

        [StringLength(20)]
        [Display(Name = "Năm Cấp")]
        public string NamCap { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }
    }
}