using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScience.Models;

namespace WebScience.Controllers
{
    public class HocViController : Controller
    {
        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();
        // GET: HocVi
        public ActionResult Index()
        {
            return RedirectToAction(nameof(DanhSachHocVi));
        }

        // GET: HocVi
        public ActionResult DanhSachHocVi()
        {
            var vm = unitOfWork.HocViRepository.Get();
            return View(vm.ToList());
        }

        // GET: HocVi/Create
        public ActionResult CreateHocVi()
        {
            var vm = new tb_HocVi();
            return View(vm);
        }

        // POST: HocVi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHocVi(tb_HocVi model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HocViRepository.Insert(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachHocVi));
            }
            return View(model);
        }

        // GET: HocVi/Edit/5
        public ActionResult EditHocVi(int id)
        {
            var vm = unitOfWork.HocViRepository.GetByID(id);
            return View(vm);
        }

        // POST: HocVi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHocVi(tb_HocVi model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HocViRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachHocVi));
            }
            return View(model);
        }

        // GET: HocVi/Delete/5
        public ActionResult DeleteHocVi(int id)
        {
            unitOfWork.HocViRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction(nameof(DanhSachHocVi));
        }

    }
}
