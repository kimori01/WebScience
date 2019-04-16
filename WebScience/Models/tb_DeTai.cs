using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WebScience.Models
{
    public class tb_DeTai
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã đề tài")]
        [Display(Name = "Mã Đề Tài")]
        public string MaDeTai { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Vui lòng nhập tên đề tài")]
        public string TenDeTai { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string TieuDe { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng chọn tác giả")]
        public string TacGia { get; set; }

        public string IdMaLyLich { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn ngày công bố")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu công bố")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? NgayCongBo { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn ngày đăng ký")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu ngày đăng ký")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? NgayDangKy { get; set; }

        [StringLength(50)]
        public string QuyMo { get; set; }

        [StringLength(500)]
        public string NoiApDung { get; set; }

        [StringLength(500)]
        public string ThoiGian { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [StringLength(500)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string Path { get; set; }
    }
}