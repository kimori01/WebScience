namespace WebScience.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelScience : DbContext
    {
        public ModelScience()
            : base("name=ModelScience")
        {
        }

        public virtual DbSet<tb_HocHam> tb_HocHam { get; set; }
        public virtual DbSet<tb_HocVi> tb_HocVi { get; set; }
        public virtual DbSet<tb_LyLich> tb_LyLich { get; set; }
        public virtual DbSet<tb_QuaTrinhCongTac> tb_QuaTrinhCongTac { get; set; }
        public virtual DbSet<tb_QuaTrinhDaoTao> tb_QuaTrinhDaoTao { get; set; }
        public virtual DbSet<tb_ToChuc> tb_ToChuc { get; set; }
        public virtual DbSet<tb_UserProfile> tb_UserProfile { get; set; }
        public virtual DbSet<tb_DeTai> tb_DeTai { get; set; }
        public virtual DbSet<tb_BaoChi> tb_BaoChi { get; set; }
        public virtual DbSet<tb_DongTacGia> tb_DongTacGia { get; set; }
        public virtual DbSet<tb_VanBang> tb_VanBang { get; set; }
        public virtual DbSet<tb_NhiemVu> tb_NhiemVu { get; set; }
        public virtual DbSet<tb_GiaiThuong> tb_GiaiThuong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_HocHam>()
                .Property(e => e.MaHocHam)
                .IsUnicode(false);

            modelBuilder.Entity<tb_HocVi>()
                .Property(e => e.MaHocVi)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.MaLyLich)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.MaHocHam)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.NamHocHam)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.MaHocVi)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.NamHocVi)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.DiDong)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LyLich>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tb_QuaTrinhDaoTao>()
                .Property(e => e.MaBacDaoTao)
                .IsUnicode(false);

            modelBuilder.Entity<tb_QuaTrinhDaoTao>()
                .Property(e => e.NamTotNghiep)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserProfile>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserProfile>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserProfile>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
