using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebScience.Models;

namespace WebScience.Controllers
{
    public class BaoChiController : Controller
    {
        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        // GET: BaoChi
        public ActionResult Index()
        {
            return RedirectToAction(nameof(DanhSachBaoChi));
        }

        public ActionResult DanhSachBaoChi(string table_search, int page = 1, int pageSize = 10)
        {
            var vm = unitOfWork.BaoChiRepository.Get().Where(x => table_search == null 
            || x.MaBaoChi.StartsWith(table_search)
            || x.TieuDeBaoChi.StartsWith(table_search)
            || x.TenBaoChi.StartsWith(table_search)).OrderByDescending(r => r.Id);

            if (Request.IsAjaxRequest())
            {
                return PartialView("PartialDanhSachBaoChi", vm);
            }
            return View(vm.ToPagedList(page, pageSize));
        }

        public ActionResult CreateBaoChi()
        {
            var vm = new tb_BaoChi();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBaoChi(tb_BaoChi model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BaoChiRepository.Insert(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachBaoChi));
            }
            return View(model);
        }

        public ActionResult EditBaoChi(int id)
        {
            var vm = unitOfWork.BaoChiRepository.Get(x => x.Id == id).FirstOrDefault();
            return View(vm);
        }

        // POST: LyLich/Edit/5
        [HttpPost]
        public ActionResult EditBaoChi(tb_BaoChi model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BaoChiRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachBaoChi));
            }
            return View(model);
        }

        public ActionResult DeleteBaoChi(int id)
        {
            unitOfWork.BaoChiRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction(nameof(DanhSachBaoChi));
        }
    }
}