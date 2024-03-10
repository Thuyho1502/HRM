using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            //Vao database truy van du lieu
            using (HRMEntities db = new HRMEntities())
            {
                var list = db.UserLogins.ToList();
                return View(list);
            }

        }

       
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();

        }
        [HttpPost]
        public ActionResult Create(UserLogin model)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    UserLogin userLogin = new UserLogin();
                    userLogin.UserName = model.UserName;
                    userLogin.Password =  HashMd5.EncryptString(model.Password);
                    userLogin.EmployeeId = model.EmployeeId;
                    userLogin.Role = 1;
                    userLogin.StatusUser = 0;
                    db.UserLogins.Add(userLogin);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View("Login","Home");
        }

        [HttpPost]
        public ActionResult LockAccount(string username)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.UserLogins.Where(x => x.UserName == username).FirstOrDefault();
                    if (item != null)
                    {
                        item.StatusUser = 0;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            return View("Login", "Home");
        }
        [HttpPost]
        public ActionResult ActiveAccount(string username)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.UserLogins.Where(x => x.UserName == username).FirstOrDefault();
                    if (item != null)
                    {
                        item.StatusUser = 1;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            return View("Login", "Home");
        }
    }
}