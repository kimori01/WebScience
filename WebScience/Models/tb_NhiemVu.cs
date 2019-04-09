using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebScience.Models
{
    public class tb_NhiemVu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập mã nhiệm vụ")]
        [Display(Name = "Mã Văn Bằng")]
        public string MaNhiemVu { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên nhiệm vụ")]
        [Display(Name = "Tên Văn Bằng")]
        public string TenNhiemVu { get; set; }

        [StringLength(50)]
        public string IdMaLyLich { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn thời gian bắt đầu")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu ngày")]
        public DateTime? ThoiGianBD { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn thời gian kết thúc")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu ngày")]
        public DateTime? ThoiGianKT { get; set; }

        [StringLength(500)]
        [Display(Name = "Chương Trình")]
        public string ChuongTrinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Tình Trạng")]
        public string TinhTrang { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }
    }
}