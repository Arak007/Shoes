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
    public class brandsController : Controller
    {
        private IBrandsMock db;

        public brandsController()
        {
            //Default option that connects to DataBase
            this.db = new EFBrands();
        }

        public brandsController(IBrandsMock ibrandsMock)
        {
            this.db = ibrandsMock; 
        }

        // GET: brands
        public ActionResult Index()
        {

            var brands = db.Brands.OrderBy(b => b.brName).ThenBy(b => b.brFounder);
            return View("Index", brands); 
        }

        // GET: brands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //brand brand = db.brands.Find(id);

            brand brand = db.Brands.SingleOrDefault(a => a.brandId == id);

            if (brand == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Details",brand);
        }

        // GET: brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "brandId,brName,brDesc,brFounder")] brand brand)
        {
            if (ModelState.IsValid)
            {
                //db.brands.Add(brand);
                //db.SaveChanges();
                db.Save(brand);
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //brand brand = db.brands.Find(id);
            brand brand = db.Brands.SingleOrDefault(a => a.brandId == id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "brandId,brName,brDesc,brFounder")] brand brand)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(brand).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //brand brand = db.brands.Find(id);
            brand brand = db.Brands.SingleOrDefault(a => a.brandId == id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id.Equals(null))
            {
                return View("Error");
            }
            //brand brand = db.brands.Find(id);
            brand brand = db.Brands.SingleOrDefault(a => a.brandId == id);

            if (brand == null)
            {
                return View("Error");
            }
           
            //brand brand = db.brands.Find(id);
            //db.brands.Remove(brand);
            db.Delete(brand);

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
