using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecyclingApp.Models;

namespace RecyclingApp.Controllers
{
    public class RecyclableItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecyclableItems
        public ActionResult Index()
        {
            // Include RecyclableType to ensure it's loaded with RecyclableItems
            var recyclableItems = db.RecyclableItems.Include(r => r.RecyclableType).ToList();
            return View(recyclableItems);
        }

        // GET: RecyclableItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Include RecyclableType in the query
            var recyclableItem = db.RecyclableItems.Include(r => r.RecyclableType).FirstOrDefault(r => r.Id == id);
            if (recyclableItem == null)
            {
                return HttpNotFound();
            }
            return View(recyclableItem);
        }

        // GET: RecyclableItems/Create
        public ActionResult Create()
        {
            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecyclableTypeId,Weight,ItemDescription")] RecyclableItem recyclableItem)
        {
            if (ModelState.IsValid)
            {
                var recyclableType = db.RecyclableTypes.Find(recyclableItem.RecyclableTypeId);
                if (recyclableType == null)
                {
                    ModelState.AddModelError("", "Invalid recyclable type.");
                }
                else if (recyclableItem.Weight < recyclableType.MinKg || recyclableItem.Weight > recyclableType.MaxKg)
                {
                    ModelState.AddModelError("Weight", $"Weight must be between {recyclableType.MinKg} kg and {recyclableType.MaxKg} kg.");
                }
                else
                {
                    db.RecyclableItems.Add(recyclableItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }


        public JsonResult GetRecyclableTypeRate(int id)
        {
            var recyclableType = db.RecyclableTypes.Find(id);
            if (recyclableType != null)
            {
                return Json(new { rate = recyclableType.Rate }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { rate = 0 }, JsonRequestBehavior.AllowGet);
        }

        // GET: RecyclableItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Include RecyclableType in the query
            var recyclableItem = db.RecyclableItems.Include(r => r.RecyclableType).FirstOrDefault(r => r.Id == id);
            if (recyclableItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecyclableTypeId,Weight,ItemDescription")] RecyclableItem recyclableItem)
        {
            if (ModelState.IsValid)
            {
                var recyclableType = db.RecyclableTypes.Find(recyclableItem.RecyclableTypeId);
                if (recyclableType == null)
                {
                    ModelState.AddModelError("", "Invalid recyclable type.");
                }
                else if (recyclableItem.Weight < recyclableType.MinKg || recyclableItem.Weight > recyclableType.MaxKg)
                {
                    ModelState.AddModelError("Weight", $"Weight must be between {recyclableType.MinKg} kg and {recyclableType.MaxKg} kg.");
                }
                else
                {
                    db.Entry(recyclableItem).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }


        // GET: RecyclableItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Include RecyclableType in the query
            var recyclableItem = db.RecyclableItems.Include(r => r.RecyclableType).FirstOrDefault(r => r.Id == id);
            if (recyclableItem == null)
            {
                return HttpNotFound();
            }
            return View(recyclableItem);
        }

        // POST: RecyclableItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecyclableItem recyclableItem = db.RecyclableItems.Find(id);
            db.RecyclableItems.Remove(recyclableItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
