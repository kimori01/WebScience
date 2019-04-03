using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebScience.Models;
using WebScience.ViewData;

namespace WebScience.Controllers
{
    public class LyLichController : Controller
    {
        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        public ActionResult Index()
        {
            return RedirectToAction(nameof(DanhSachLyLich));
        }

        // GET: LyLich
        public ActionResult DanhSachLyLich(string table_search, int page = 1, int pageSize = 10)
        {
            //ViewBag.PageSize = new List<SelectListItem>()
            // {
            //     new SelectListItem() { Value="5", Text= "5" },
            //     new SelectListItem() { Value="10", Text= "10" },
            //     new SelectListItem() { Value="15", Text= "15" },
            //     new SelectListItem() { Value="25", Text= "25" },
            //     new SelectListItem() { Value="50", Text= "50" },
            // };

            var vm = unitOfWork.LyLichRepository.Get().Where(x => table_search == null || x.MaLyLich.StartsWith(table_search) || x.HoVaTen.StartsWith(table_search)).OrderByDescending(r => r.Id);

            if (Request.IsAjaxRequest())
            {
                return PartialView("PartialDanhSachLyLich", vm);
            }
            return View(vm.ToPagedList(page, pageSize));
        }

        public ActionResult CreateLyLich()
        {
            ViewBag.HocHam = unitOfWork.HocHamRepository.Get();
            ViewBag.HocVi = unitOfWork.HocViRepository.Get();
            var vm = new tb_LyLich();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLyLich(tb_LyLich model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.HocHam = unitOfWork.HocHamRepository.Get();
            ViewBag.HocVi = unitOfWork.HocViRepository.Get();
            if (ModelState.IsValid)
            {
                unitOfWork.LyLichRepository.Insert(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachLyLich));
            }
            return View(model);
        }

        // GET: LyLich/Edit/5
        public ActionResult EditLyLich(int id)
        {
            ViewBag.HocHam = unitOfWork.HocHamRepository.Get();
            ViewBag.HocVi = unitOfWork.HocViRepository.Get();
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "Nam", Value = "Nam" });
            listItems.Add(new SelectListItem { Text = "Nữ", Value = "Nữ" });
            ViewBag.GioiTinh = listItems;

            var vm = unitOfWork.LyLichRepository.Get(x => x.Id == id).FirstOrDefault();
            return View(vm);
        }

        // POST: LyLich/Edit/5
        [HttpPost]
        public ActionResult EditLyLich(tb_LyLich model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LyLichRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachLyLich));
            }
            return View(model);
        }

        // GET: LyLich/Delete/5
        public ActionResult DeleteLyLich(int id)
        {
            unitOfWork.LyLichRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction(nameof(DanhSachLyLich));
        }

        public ActionResult ThongTinLyLich(int id)
        {
            var _LyLich = GetLyLichByID(id);
            ViewBag.LyLich = _LyLich;
            ViewBag.ToChuc = GetToChuc(_LyLich);
            ViewBag.DaoTao = GetDaoTao(_LyLich);
            ViewBag.CongTac = GetCongTac(_LyLich);
            ViewBag.HocVi = unitOfWork.HocViRepository.Get().ToList();
            return View();
        }

        public ActionResult PartialToChuc(ViewToChucLyLich model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult EditToChuc(FormCollection model)
        {
            var vmtochuc = unitOfWork.ToChucRepository.Get().Where(x => x.MaTaiKhoan == Request.Form["MaLyLich"].ToString()).FirstOrDefault();

            if (vmtochuc == null)
            {
                var vm = new tb_ToChuc();
                vm.MaTaiKhoan = Request.Form["MaLyLich"];
                vm.TenToChuc = Request.Form["TenToChuc"];
                vm.TenNguoiLanhDao = Request.Form["TenNguoiLanhDao"];
                vm.DienThoaiLanhDao = Request.Form["DienThoaiLanhDao"];
                vm.DiaChiToChuc = Request.Form["DiaChiToChuc"];
                vm.GhiChu = string.Empty;
                unitOfWork.ToChucRepository.Insert(vm);
                unitOfWork.Save();
            }
            else
            {
                vmtochuc.TenToChuc = Request.Form["TenToChuc"];
                vmtochuc.TenNguoiLanhDao = Request.Form["TenNguoiLanhDao"];
                vmtochuc.DienThoaiLanhDao = Request.Form["DienThoaiLanhDao"];
                vmtochuc.DiaChiToChuc = Request.Form["DiaChiToChuc"];
                unitOfWork.ToChucRepository.Update(vmtochuc);
                unitOfWork.Save();
            }
            return RedirectToAction("ThongTinLyLich", new { Id = Request.Form["IdLyLich"] });
        }

        public ActionResult PartialQuaTrinhDaoTao(List<ViewDaoTaoLyLich> model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDaoTao(FormCollection model)
        {
            var vm = new tb_QuaTrinhDaoTao();
            vm.MaTaiKhoan = Request.Form["MaLyLich"];
            vm.MaBacDaoTao = Request.Form["MaBacDaoTao"];
            vm.NamTotNghiep = Request.Form["NamTotNghiep"];
            vm.NoiDaoTao = Request.Form["NoiDaoTao"];
            vm.ChuyenMon = Request.Form["ChuyenMon"];
            vm.GhiChu = string.Empty;
            unitOfWork.QuaTrinhDaoTaoRepository.Insert(vm);
            unitOfWork.Save();

            return RedirectToAction("ThongTinLyLich", new { Id = Request.Form["IdLyLich"] });
        }

        public ActionResult EditDaoTao(int Id, int IdLyLich, string MaLyLich)
        {
            var vm = new ViewDaoTaoLyLich();
            var model = unitOfWork.QuaTrinhDaoTaoRepository.Get(x => x.Id == Id).FirstOrDefault();
            vm.Id = Id;
            vm.IdLyLich = IdLyLich;
            vm.MaLyLich = MaLyLich;
            vm.MaBacDaoTao = model.MaBacDaoTao;
            vm.NamTotNghiep = model.NamTotNghiep;
            vm.NoiDaoTao = model.NoiDaoTao;
            vm.ChuyenMon = model.ChuyenMon;
            vm.GhiChu = string.Empty;
            ViewBag.HocVi = unitOfWork.HocViRepository.Get().ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditDaoTao(ViewDaoTaoLyLich model)
        {
            var vm = unitOfWork.QuaTrinhDaoTaoRepository.Get(x => x.Id == model.Id && x.MaTaiKhoan == model.MaLyLich).FirstOrDefault();
            vm.MaBacDaoTao = model.MaBacDaoTao;
            vm.NamTotNghiep = model.NamTotNghiep;
            vm.NoiDaoTao = model.NoiDaoTao;
            vm.ChuyenMon = model.ChuyenMon;
            unitOfWork.QuaTrinhDaoTaoRepository.Update(vm);
            unitOfWork.Save();
            return RedirectToAction("ThongTinLyLich", new { Id = model.IdLyLich });
        }

        public ActionResult DeleteDaoTao(int Id, int IdLyLich)
        {
            var vm = unitOfWork.QuaTrinhDaoTaoRepository.Get(x => x.Id == Id).FirstOrDefault();
            unitOfWork.QuaTrinhDaoTaoRepository.Delete(vm);
            unitOfWork.Save();
            return RedirectToAction("ThongTinLyLich", new { Id = IdLyLich });
        }


        public ActionResult PartialQuaTrinhCongTac(List<ViewCongTacLyLich> model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCongTac(ViewCongTacLyLich model)
        {
            var vm = new tb_QuaTrinhCongTac();
            vm.MaTaiKhoan = model.MaLyLich;
            vm.ThoiGian = model.ThoiGian;
            vm.ToChucCongTac = model.ToChucCongTac;
            vm.ViTriCongTac = model.ViTriCongTac;
            vm.DiaChiCongTac = model.DiaChiCongTac;
            vm.GhiChu = string.Empty;
            unitOfWork.QuaTrinhCongTacRepository.Insert(vm);
            unitOfWork.Save();

            return RedirectToAction("ThongTinLyLich", new { Id = model.IdLyLich });
        }

        public ActionResult EditCongTac(int Id, int IdLyLich, string MaLyLich)
        {
            var vm = new ViewCongTacLyLich();
            var model = unitOfWork.QuaTrinhCongTacRepository.Get(x => x.Id == Id).FirstOrDefault();
            vm.Id = Id;
            vm.IdLyLich = IdLyLich;
            vm.MaLyLich = MaLyLich;
            vm.ThoiGian = model.ThoiGian;
            vm.ToChucCongTac = model.ToChucCongTac;
            vm.ViTriCongTac = model.ViTriCongTac;
            vm.DiaChiCongTac = model.DiaChiCongTac;
            vm.GhiChu = string.Empty;
            return View(vm);
        } 

        [HttpPost]
        public ActionResult EditCongTac(ViewCongTacLyLich model)
        {
            var vm = unitOfWork.QuaTrinhCongTacRepository.Get(x => x.Id == model.Id).FirstOrDefault();
            vm.ThoiGian = model.ThoiGian;
            vm.ToChucCongTac = model.ToChucCongTac;
            vm.ViTriCongTac = model.ViTriCongTac;
            vm.DiaChiCongTac = model.DiaChiCongTac;
            vm.GhiChu = string.Empty;
            unitOfWork.QuaTrinhCongTacRepository.Update(vm);
            unitOfWork.Save();

            return RedirectToAction("ThongTinLyLich", new { Id = model.IdLyLich });
        }

        public ActionResult DeleteCongTac(int Id, int IdLyLich)
        {
            var vm = unitOfWork.QuaTrinhCongTacRepository.Get(x => x.Id == Id).FirstOrDefault();
            unitOfWork.QuaTrinhCongTacRepository.Delete(vm);
            unitOfWork.Save();

            return RedirectToAction("ThongTinLyLich", new { Id = IdLyLich });
        }

        private List<ViewCongTacLyLich> GetCongTac(ViewLyLich daotao)
        {
            var model = new List<ViewCongTacLyLich>();
            var result = unitOfWork.QuaTrinhCongTacRepository.Get(x => x.MaTaiKhoan == daotao.MaLyLich);
            if (result.Count() == 0)
            {
                var vm = new ViewCongTacLyLich();
                vm.IdLyLich = daotao.Id;
                vm.MaLyLich = daotao.MaLyLich;
                model.Add(vm);
                return model;
            }
            else
            {
                var vm = (from s in result
                          select new ViewCongTacLyLich
                          {
                              Id = s.Id,
                              IdLyLich = daotao.Id,
                              MaLyLich = s.MaTaiKhoan,
                              ThoiGian = s.ThoiGian,
                              ViTriCongTac = s.ViTriCongTac,
                              ToChucCongTac = s.ToChucCongTac,
                              DiaChiCongTac = s.DiaChiCongTac,
                              GhiChu = s.GhiChu
                          }).OrderByDescending(x => x.ThoiGian).ToList();

                return vm;
            }
        }
        private List<ViewDaoTaoLyLich> GetDaoTao(ViewLyLich daotao)
        {
            var model = new List<ViewDaoTaoLyLich>();
            var result = unitOfWork.QuaTrinhDaoTaoRepository.Get(x => x.MaTaiKhoan == daotao.MaLyLich);
            if (result.Count() == 0)
            {
                var vm = new ViewDaoTaoLyLich();
                vm.IdLyLich = daotao.Id;
                vm.MaLyLich = daotao.MaLyLich;
                model.Add(vm);
                return model;
            }
            else
            {
                var vm = (from s in result
                          select new ViewDaoTaoLyLich
                          {
                             Id = s.Id,
                             IdLyLich = daotao.Id,
                             MaLyLich = s.MaTaiKhoan,
                             MaBacDaoTao = s.MaBacDaoTao,
                             TenBacDaoTao = unitOfWork.HocViRepository.Get(x => x.MaHocVi == s.MaBacDaoTao).FirstOrDefault().TenHocVi,
                             NoiDaoTao = s.NoiDaoTao,
                             ChuyenMon = s.ChuyenMon,
                             NamTotNghiep = s.NamTotNghiep,
                             GhiChu = s.GhiChu
                         }).OrderByDescending(x => x.NamTotNghiep).ToList();

                return vm;
            }
        }

        private ViewToChucLyLich GetToChuc(ViewLyLich lylich)
        {
            var result = unitOfWork.ToChucRepository.Get(x => x.MaTaiKhoan == lylich.MaLyLich).FirstOrDefault();
            if (result == null)
            {
                var vm = new ViewToChucLyLich();
                vm.IdLyLich = lylich.Id;
                vm.MaLyLich = lylich.MaLyLich;
                return vm;
            }
            else
            {
                var vm = new ViewToChucLyLich();
                vm.Id = result.Id;
                vm.IdLyLich = lylich.Id;
                vm.MaLyLich = lylich.MaLyLich;
                vm.TenToChuc = result.TenToChuc;
                vm.TenNguoiLanhDao = result.TenNguoiLanhDao;
                vm.DienThoaiLanhDao = result.DienThoaiLanhDao;
                vm.DiaChiToChuc = result.DiaChiToChuc;
                return vm;
            }
        }

        private ViewLyLich GetLyLichByID(int id)
        {
            var _LyLich = unitOfWork.LyLichRepository.Get(x => x.Id == id).FirstOrDefault();
            ViewLyLich viewLyLich = new ViewLyLich();
            viewLyLich.Id = _LyLich.Id;
            viewLyLich.MaLyLich = _LyLich.MaLyLich;
            viewLyLich.HoVaTen = _LyLich.HoVaTen;
            viewLyLich.MaHocHam = _LyLich.MaHocHam;
            viewLyLich.TenHocHam = unitOfWork.HocHamRepository.Get(x => x.MaHocHam == _LyLich.MaHocHam).First().TenHocHam;
            viewLyLich.NamHocHam = _LyLich.NamHocHam;
            viewLyLich.MaHocVi = _LyLich.MaHocVi;
            viewLyLich.TenHocVi = unitOfWork.HocViRepository.Get(x => x.MaHocVi == _LyLich.MaHocVi).First().TenHocVi;
            viewLyLich.NamHocVi = _LyLich.NamHocVi;
            viewLyLich.DiaChi = _LyLich.DiaChi;
            viewLyLich.DienThoai = _LyLich.DienThoai;
            viewLyLich.DiDong = _LyLich.DiDong;
            viewLyLich.Fax = _LyLich.Fax;
            viewLyLich.Email = _LyLich.Email;
            return viewLyLich;
        }
    }
}
