using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebScience.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult ListTaiKhoan()
        {
            return View();
        }


        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaiKhoan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaiKhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
