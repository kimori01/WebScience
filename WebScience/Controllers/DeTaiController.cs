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
            var vm = unitOfWork.LyLichRepository.Get().Where(x => table_search == null || x.MaLyLich.StartsWith(table_search) || x.HoVaTen.StartsWith(table_search)).OrderByDescending(r => r.Id);
            return Json(vm, JsonRequestBehavior.AllowGet);
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
            return View(vm);
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
                    vm.FileName = path;
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