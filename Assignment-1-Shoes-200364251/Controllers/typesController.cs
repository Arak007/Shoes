using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_1_Shoes_200364251.Models;

namespace Assignment_1_Shoes_200364251.Controllers
{
    public class typesController : Controller
    {
        private ShoesModel db = new ShoesModel();

        // GET: types
        public ActionResult Index()
        {
            var types = db.types.Include(q => q.brand);
            return View(types.OrderBy(a => a.brand.brName).ThenBy(a => a.moName).ToList());
        }

        // GET: types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // GET: types/Create
        public ActionResult Create()
        {
            ViewBag.brandId = new SelectList(db.brands, "brandId", "brName");
            return View();
        }

        // POST: types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "moId,moName,moDesc,moColours,brandId")] type type)
        {
            if (ModelState.IsValid)
            {
                db.types.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brandId = new SelectList(db.brands, "brandId", "brName", type.brandId);
            return View(type);
        }

        // GET: types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.brandId = new SelectList(db.brands, "brandId", "brName", type.brandId);
            return View(type);
        }

        // POST: types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "moId,moName,moDesc,moColours,brandId")] type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brandId = new SelectList(db.brands, "brandId", "brName", type.brandId);
            return View(type);
        }

        // GET: types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            type type = db.types.Find(id);
            db.types.Remove(type);
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
