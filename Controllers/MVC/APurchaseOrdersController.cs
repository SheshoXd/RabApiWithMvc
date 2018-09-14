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
    public class APurchaseOrdersController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: APurchaseOrders
        public ActionResult Index()
        {
            var purchaseOrders = db.PurchaseOrders.Include(p => p.Employee).Include(p => p.Supplier);
            return View(purchaseOrders.ToList());
        }

        // GET: APurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: APurchaseOrders/Create
        public ActionResult Create()
        {
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName");
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName");
            return View();
        }

        // POST: APurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,OrderType,EmpId,SuppId,OrderDate,PaymantType,TotalPrice,Debit,Creditor,PostingStats,DateCreated,IsDeleted")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", purchaseOrder.EmpId);
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName", purchaseOrder.SuppId);
            return View(purchaseOrder);
        }

        // GET: APurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", purchaseOrder.EmpId);
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName", purchaseOrder.SuppId);
            return View(purchaseOrder);
        }

        // POST: APurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,OrderType,EmpId,SuppId,OrderDate,PaymantType,TotalPrice,Debit,Creditor,PostingStats,DateCreated,IsDeleted")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", purchaseOrder.EmpId);
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName", purchaseOrder.SuppId);
            return View(purchaseOrder);
        }

        // GET: APurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: APurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
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
