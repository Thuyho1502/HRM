using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class HomeController : Controller
    {
        HRMEntities db = new HRMEntities();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin modelLogin)
        {
            if (ModelState.IsValid)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    if (string.IsNullOrEmpty(modelLogin.UserName) || string.IsNullOrEmpty(modelLogin.Password))
                    {
                        ModelState.AddModelError("", "PLease input UserName and Password!");
                        return View();
                    }
                    string hashPasword = HashMd5.EncryptString(modelLogin.Password);
                    var userLogin = db.UserLogins.Where(x => x.UserName == modelLogin.UserName 
                    && x.Password == hashPasword).FirstOrDefault();
                    if (userLogin == null)
                    {
                        ModelState.AddModelError("", "UserName or Password not exits !");
                        return View();
                    }
                    // Status == 1 => user lock => no login
                    if (userLogin.StatusUser == 0)
                    {
                        ModelState.AddModelError("", "User disable, can not login");
                        return View();
                    }
                    //Login successfull
                    //Save session
                    Session["UserId"] = userLogin.EmployeeId;
                    Session["UserName"] = userLogin.UserName;
                    Session["UserId"] = userLogin.Password;

                    return RedirectToAction("Dashboard");

                }
            }

            return View();
            
        }

    }
}