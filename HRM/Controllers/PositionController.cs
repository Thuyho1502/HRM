using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            using (HRMEntities db = new HRMEntities())
            {
                var list = db.Positions.ToList();
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
        public ActionResult Create(Position model)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    Position position = new Position();
                    position.PositionId = model.PositionId;
                    position.PositionName = model.PositionName;
                    position.isActive = true;
                    db.Positions.Add(position);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View("Login", "Home");
        }

        [HttpPost]
        public ActionResult LockPosition(string positionId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Positions.Where(x => x.PositionId == positionId).FirstOrDefault();
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
        public ActionResult ActivePosition(string positionId)
        {
            if (Session["UserID"] != null)
            {
                using (HRMEntities db = new HRMEntities())
                {
                    var item = db.Positions.Where(x => x.PositionId == positionId).FirstOrDefault();
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