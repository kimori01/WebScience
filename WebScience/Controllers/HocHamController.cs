using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScience.Models;

namespace WebScience.Controllers
{
    public class HocHamController : Controller
    {
        private UnitOfWork.UnitOfWork unitOfWork = new UnitOfWork.UnitOfWork();

        // GET: HocHam
        public ActionResult Index()
        {
            return RedirectToAction(nameof(DanhSachHocHam));
        }

        // GET: HocHam
        public ActionResult DanhSachHocHam()
        {
            var vm = unitOfWork.HocHamRepository.Get();
            return View(vm.ToList());
        }

        // GET: HocHam/Create
        public ActionResult CreateHocHam()
        {
            var vm = new tb_HocHam();
            return View(vm);
        }

        // POST: HocHam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHocHam(tb_HocHam model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HocHamRepository.Insert(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachHocHam));
            }
            return View(model);
        }

        // GET: HocHam/Edit/5
        public ActionResult EditHocHam(int id)
        {
            var vm = unitOfWork.HocHamRepository.GetByID(id);
            return View(vm);
        }

        // POST: HocHam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHocHam(tb_HocHam model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.HocHamRepository.Update(model);
                unitOfWork.Save();
                return RedirectToAction(nameof(DanhSachHocHam));
            }
            return View(model);
        }

        // GET: HocHam/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.HocHamRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction(nameof(DanhSachHocHam));
        }
    }
}
