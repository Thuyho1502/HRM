using Antlr.Runtime.Misc;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class NationController : Controller
    {
      
        // GET: Nation
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            using (HRMEntities db = new HRMEntities())
            {
                var list = db.Nations.ToList();
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
        public ActionResult Create(Nation model)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    Nation nation = new Nation();
                    nation.NationName = model.NationName;
                    nation.NationId = model.NationId;
                    nation.isActive = true;
                    db.Nations.Add(nation);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View("Login", "Home");
        }

        [HttpPost]
        public ActionResult LockNation(string nationId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Nations.Where(x => x.NationId == nationId).FirstOrDefault();
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
        public ActionResult ActiveNation(string nationId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Nations.Where(x => x.NationId == nationId).FirstOrDefault();
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