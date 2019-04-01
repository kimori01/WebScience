namespace WebScience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_HocHam
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập mã học hàm")]
        public string MaHocHam { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên học hàm")]
        public string TenHocHam { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }
    }
}
