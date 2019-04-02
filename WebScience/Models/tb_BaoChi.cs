﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WebScience.Models
{
    public class tb_BaoChi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã báo chí")]
        [Display(Name = "Mã Đề Tài")]
        public string MaBaoChi { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Vui lòng nhập tên báo chí")]
        public string TenBaoChi { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string TieuDeBaoChi { get; set; }

        [StringLength(500)]
        public string NoiDungBaoChi { get; set; }

        public string IdMaLyLich { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng chọn tác giả")]
        public string TacGiaBaoChi { get; set; }

        public string IdMaDeTai { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng chọn đề tài")]
        public string TenDeTai { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn ngày công bố")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu ngày tháng")]
        public DateTime? NgayXuatBan { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Vui lòng chọn ngày đăng ký")]
        [DataType(DataType.DateTime, ErrorMessage = "Không đúng kiểu ngày đăng ký")]
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
    }
}