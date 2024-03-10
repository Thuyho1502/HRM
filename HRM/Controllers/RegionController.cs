using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            using (HRMEntities db = new HRMEntities())
            {
                var list = db.Regions.ToList();
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
        public ActionResult Create(Region model)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    Region region = new Region();
                    region.RegionName = model.RegionName;
                    region.RegionId = model.RegionId;
                    region.isActive = true;
                    db.Regions.Add(region);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View("Login", "Home");
        }


        [HttpPost]
        public ActionResult LockRegion(string regionId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Regions.Where(x => x.RegionId == regionId).FirstOrDefault();
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
        public ActionResult ActiveRegion(string regionId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Regions.Where(x => x.RegionId == regionId).FirstOrDefault();
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