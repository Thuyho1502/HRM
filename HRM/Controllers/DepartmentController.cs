using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            using (HRMEntities db = new HRMEntities())
            {
                var list = db.Departments.ToList();
                return View(list);
            }

        }
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department model)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    Department department = new Department();
                    department.DepartmentId = model.DepartmentId;
                    department.DepartmentName = model.DepartmentName;
                    department.isActive = true;
                    db.Departments.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View("Login", "Home");
        }


        [HttpPost]
        public ActionResult LockDepartment(string departmentId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefault();
                    if (item != null)
                    {
                        item.isActive = false;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            return View("Login", "Home");
        }
        [HttpPost]
        public ActionResult ActiveDepartment(string departmentId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefault();
                    if (item != null)
                    {
                        item.isActive = true;
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