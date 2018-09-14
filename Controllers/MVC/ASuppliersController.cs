using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers.MVC
{
    public class ASuppliersController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: ASuppliers
        public ActionResult Index()
        {
            var suppliers = db.Suppliers.Include(s => s.Area);
            return View(suppliers.ToList());
        }

        // GET: ASuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: ASuppliers/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1");
            return View();
        }

        // POST: ASuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuppId,SuppName,Type,fullAddress,OwnerName,PhoneNo,AreaId,DateCreated,IsDeleted")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1", supplier.AreaId);
            return View(supplier);
        }

        // GET: ASuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1", supplier.AreaId);
            return View(supplier);
        }

        // POST: ASuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuppId,SuppName,Type,fullAddress,OwnerName,PhoneNo,AreaId,DateCreated,IsDeleted")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1", supplier.AreaId);
            return View(supplier);
        }

        // GET: ASuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: ASuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
