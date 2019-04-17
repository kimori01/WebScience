using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WebScience.Models;
using System.Collections.Generic;
using WebScience.ViewData;
using System.Linq;

namespace WebScience.Reports
{
    public partial class XtraReport_LyLichKhoaHoc : DevExpress.XtraReports.UI.XtraReport
    {
        public int IdLyLich;

        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        WebScience.Reports.Sub.XtraReport_Sub_QuaTrinhDaoTao sub_quatrinhdaotao = new Reports.Sub.XtraReport_Sub_QuaTrinhDaoTao();

        public XtraReport_LyLichKhoaHoc()
        {
            InitializeComponent();
        }

        public void QuaTrinhDaoTao()
        {
            sub_quatrinhdaotao.DataSource = unitOfWork.QuaTrinhDaoTaoRepository.Get(x => x.IdMaLyLich == IdLyLich.ToString());
            xrSubreport1.ReportSource = sub_quatrinhdaotao;
        }

        public IEnumerable<ViewReportThongTinLyLich> GetThongTinLyLich(int IdLyLich)
        {
            var lylich = unitOfWork.LyLichRepository.Get(x => x.Id == IdLyLich);
            var hocham = unitOfWork.HocHamRepository.Get();
            var hocvi = unitOfWork.HocViRepository.Get();
            var tochuc = unitOfWork.ToChucRepository.Get(x => x.IdMaLyLich == IdLyLich.ToString());

            var model = from l in lylich
                        join hh in hocham on l.MaHocHam equals hh.MaHocHam
                        join hv in hocvi on l.MaHocVi equals hv.MaHocVi
                        select new ViewReportThongTinLyLich
                        {
                            Id = l.Id,
                            MaLyLich = l.MaLyLich,
                            HoVaTen = l.HoVaTen,
                            NgaySinh = l.NgaySinh.ToString(),
                            GioiTinh = l.GioiTinh,
                            MaHocHam = l.MaHocHam,
                            TenHocHam = hh.TenHocHam,
                            NamHocHam = l.NamHocHam,
                            MaHocVi = l.MaHocVi,
                            TenHocVi = hv.TenHocVi,
                            NamHocVi = l.NamHocVi,
                            ChucDanh = l.ChucDanh,
                            ChucVu = l.ChucVu,
                            DiaChi = l.DiaChi,
                            DienThoai = l.DienThoai,
                            DiDong = l.DiDong,
                            Fax = l.Fax,
                            Email = l.Email,
                            MaToChuc = (tochuc.Count() == 0 ? string.Empty : tochuc.FirstOrDefault(x => x.IdMaLyLich == l.Id.ToString()).Id.ToString()),
                            TenToChuc = (tochuc.Count() == 0 ? string.Empty : tochuc.FirstOrDefault(x => x.IdMaLyLich == l.Id.ToString()).TenToChuc),
                            TenNguoiLanhDao = (tochuc.Count() == 0 ? string.Empty : tochuc.FirstOrDefault(x => x.IdMaLyLich == l.Id.ToString()).TenNguoiLanhDao),
                            DienThoaiLanhDao = (tochuc.Count() == 0 ? string.Empty : tochuc.FirstOrDefault(x => x.IdMaLyLich == l.Id.ToString()).DienThoaiLanhDao),
                            DiaChiToChuc = (tochuc.Count() == 0 ? string.Empty : tochuc.FirstOrDefault(x => x.IdMaLyLich == l.Id.ToString()).DiaChiToChuc)
                        };

            return model;
        }
    }
}
