using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScience.Models;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using WebScience.UnitOfWork.Interface;

namespace WebScience.Controllers
{
    public class AccountController : Controller
    {
        private IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ModelScience"].ConnectionString);

        // GET: Account
        public ActionResult Login()
        {
            var vm = new tb_UserProfile();
            vm.IsActive = false;
            vm.RememberMe = false;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tb_UserProfile model)
        {

            if(string.IsNullOrEmpty(model.UserName)) 
            {
                ModelState.AddModelError(string.Empty, "Vui lòng nhập tài khoản!");
                return View();
            }
            if (string.IsNullOrEmpty(model.Password)) 
            {
                ModelState.AddModelError(string.Empty, "Vui lòng nhập mật khẩu!");
                return View();
            }

            var vm = dbConnection.Query<tb_UserProfile>("SELECT * FROM tb_UserProfile WHERE UserName = @UserName AND Password = @Password", 
                new { UserName = model.UserName, Password = model.Password });

            if(vm.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không đúng!");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}