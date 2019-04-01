namespace WebScience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_LyLich
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage ="Vui lòng nhập mã lý lịch")]
        public string MaLyLich { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên lý lịch")]
        public string HoVaTen { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập chọn học hàm")]
        public string MaHocHam { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập năm học")]
        public string NamHocHam { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng chọn học vị")]
        public string MaHocVi { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập năm học vị")]
        public string NamHocVi { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }

        [StringLength(20)]
        public string DiDong { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }
    }
}
