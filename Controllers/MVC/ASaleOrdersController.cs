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
    public class ASaleOrdersController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: ASaleOrders
        public ActionResult Index()
        {
            var saleOrders = db.SaleOrders.Include(s => s.Client).Include(s => s.Employee);
            return View(saleOrders.ToList());
        }

        // GET: ASaleOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            return View(saleOrder);
        }

        // GET: ASaleOrders/Create
        public ActionResult Create()
        {
            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName");
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName");
            return View();
        }

        // POST: ASaleOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlOrdId,EmpId,ClntId,SlOrdDate,PaymantType,TotalPrice,Debit,Creditor,PostingStats,DateCreated,IsDeleted")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.SaleOrders.Add(saleOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName", saleOrder.ClntId);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", saleOrder.EmpId);
            return View(saleOrder);
        }

        // GET: ASaleOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName", saleOrder.ClntId);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", saleOrder.EmpId);
            return View(saleOrder);
        }

        // POST: ASaleOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlOrdId,EmpId,ClntId,SlOrdDate,PaymantType,TotalPrice,Debit,Creditor,PostingStats,DateCreated,IsDeleted")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName", saleOrder.ClntId);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpId", "EmpName", saleOrder.EmpId);
            return View(saleOrder);
        }

        // GET: ASaleOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            return View(saleOrder);
        }

        // POST: ASaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            db.SaleOrders.Remove(saleOrder);
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
