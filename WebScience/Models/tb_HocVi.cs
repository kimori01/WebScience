namespace WebScience.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_HocVi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập mã học vị")]
        public string MaHocVi { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên học vị")]
        [Display(Name = "Tên Học Vị")]
        public string TenHocVi { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }
    }
}
