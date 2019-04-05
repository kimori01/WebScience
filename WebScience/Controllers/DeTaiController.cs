using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScience.Models;
using WebScience.ViewData;

namespace WebScience.Controllers
{
    public class DeTaiController : Controller
    {
        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        public ActionResult Index()
        {
            return RedirectToAction(nameof(DanhSachDeTai));
        }
        // GET: DeTai
        public ActionResult DanhSachDeTai(string table_search, int page = 1, int pageSize = 10)
        {
            var vm = unitOfWork.DeTaiRepository.Get().Where(x => table_search == null || x.MaDeTai.StartsWith(table_search) || x.TenDeTai.StartsWith(table_search)).OrderByDescending(r => r.Id);

            if (Request.IsAjaxRequest())
            {
                return PartialView("PartialDanhSachDeTai", vm);
            }
            return View(vm.ToPagedList(page, pageSize));
        }

        public ActionResult CreateDeTai()
        {
            var vm = new tb_DeTai();
            return View(vm);
        }

        public JsonResult TimKiemLyLich(string table_search)
        {
            if(!string.IsNullOrEmpty(table_search))
            {
                var vm = unitOfWork.LyLichRepository.Get().Where(x => table_search == null || x.MaLyLich.StartsWith(table_search) || x.HoVaTen.StartsWith(table_search)).OrderByDescending(r => r.Id);
                return Json(vm, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var vm = new List<tb_LyLich>();
                return Json(vm.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult TimKiemDeTai(string table_search)
        {
            if (!string.IsNullOrEmpty(table_search))
            {
                var vm = unitOfWork.DeTaiRepository.Get().Where(x => table_search == null 
                || x.MaDeTai.StartsWith(table_search)
                || x.TenDeTai.StartsWith(table_search)).OrderByDescending(r => r.Id);
                return Json(vm, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var vm = new List<tb_DeTai>();
                return Json(vm.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDeTai(tb_DeTai model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DeTaiRepository.Insert(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachDeTai));
            }
            return View(model);
        }

        public ActionResult EditDeTai(int id)
        {
            var vm = unitOfWork.DeTaiRepository.Get(x => x.Id == id).FirstOrDefault();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDeTai(tb_DeTai model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DeTaiRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachDeTai));
            }
            return View(model);
        }

        public ActionResult DeleteDeTai(int id)
        {
            var vm = unitOfWork.DeTaiRepository.Get(x => x.Id == id).FirstOrDefault();
            unitOfWork.DeTaiRepository.Delete(vm);
            unitOfWork.Save();
            return RedirectToAction(nameof(DanhSachDeTai));
        }

        public ActionResult ThongTinDeTai(int id)
        {
            var vm = unitOfWork.DeTaiRepository.Get(x => x.Id == id).FirstOrDefault();
            ViewData["DongTacGia"] = unitOfWork.DongTacGiaRepository.Get(x => x.IdMaDeTai == id.ToString());
            ViewData["BaoChi"] = unitOfWork.BaoChiRepository.Get(x => x.IdMaDeTai == vm.MaDeTai);
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateDongTacGia(FormCollection model)
        {
            var vm = new tb_DongTacGia();
            vm.IdMaLyLich = Request.Form["IdMaLyLich"];
            vm.TenDongTacGia = Request.Form["TenDongTacGia"];
            vm.MaDeTai = Request.Form["MaDeTai"];
            vm.IdMaDeTai = Request.Form["IdMaDeTai"];
            vm.NgayThamGia = DateTime.Parse(Request.Form["NgayThamGia"].ToString());
            vm.GhiChu = string.Empty;

            var countdongtacgia = unitOfWork.DongTacGiaRepository.Get(x => x.IdMaLyLich == vm.IdMaLyLich);
            if (countdongtacgia.Count() > 0)
            {
                TempData["Message"] = "Đồng tác giả này đã có trong hệ thống!";
                return RedirectToAction(nameof(ThongTinDeTai), new { id = vm.IdMaDeTai });
            }
            var countlylich = unitOfWork.LyLichRepository.Get(x => x.Id == int.Parse(vm.IdMaLyLich));
            if (countlylich.Count() > 0)
            {
                TempData["Message"] = "Đồng tác giả này là tác giả của đề tài!";
                return RedirectToAction(nameof(ThongTinDeTai), new { id = vm.IdMaDeTai });
            }

            unitOfWork.DongTacGiaRepository.Insert(vm);
            unitOfWork.Save();
            return RedirectToAction(nameof(ThongTinDeTai), new { id = vm.IdMaDeTai });
        }

        public ActionResult DeleteDongTacGia(string IdMaLyLich, string IdMaDeTai)
        {
            var vm = unitOfWork.DongTacGiaRepository.Get(x => x.IdMaLyLich == IdMaLyLich.ToString() && x.IdMaDeTai == IdMaDeTai);
            unitOfWork.DongTacGiaRepository.Delete(vm);
            unitOfWork.Save();
   

            return RedirectToAction(nameof(ThongTinDeTai), new { id = IdMaDeTai });
        }

        [HttpPost]
        public ActionResult UpdateFile(HttpPostedFileBase file, int Id)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/files"), Path.GetFileName(file.FileName));
                    var vm = unitOfWork.DeTaiRepository.Get(x => x.Id == Id).FirstOrDefault();
                    vm.Path = path;
                    vm.FileName = file.FileName;
                    unitOfWork.DeTaiRepository.Update(vm);
                    unitOfWork.Save();
                    file.SaveAs(path);

                    return RedirectToAction(nameof(ThongTinDeTai), new { Id = Id });
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
        
    }
}