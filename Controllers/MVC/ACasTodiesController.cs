using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabApiWithMvc.Models;
using System.Net.Http;

namespace RabApiWithMvc.Controllers.MVC
{
    public class ACasTodiesController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: ACasTodies
        public ActionResult Index()
        {
            return View(db.CasTodies.ToList());
        }

        // GET: ACasTodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasTody casTody = db.CasTodies.Find(id);
            if (casTody == null)
            {
                return HttpNotFound();
            }
            return View(casTody);
        }

        // GET: ACasTodies/Create
        public ActionResult Create()
        {
          ViewBag.Cars = db.Cars.ToList();
          
            ViewBag.Emps = db.Employees.ToList();
                ViewBag.Num = GetNewNumbrt();
            return View();
        }

        private int GetNewNumbrt  ()
        {

            return db.CasTodies.Count() + 1;
        }

       


        
        // POST: ACasTodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CastodyId,FildType,FildId,CasDebet,CasCredeit,CasFor,CasDate,DateCreated,isDeleted")] CasTody casTody)
        {
            if (ModelState.IsValid)
            {
                db.CasTodies.Add(casTody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casTody);
        }

        // GET: ACasTodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasTody casTody = db.CasTodies.Find(id);
            if (casTody == null)
            {
                return HttpNotFound();
            }
            return View(casTody);
        }

        // POST: ACasTodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CastodyId,CarId,CasDebet,CasCredeit,CasFor,CasDate,DateCreated,isDeleted")] CasTody casTody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casTody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casTody);
        }

        // GET: ACasTodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasTody casTody = db.CasTodies.Find(id);
            if (casTody == null)
            {
                return HttpNotFound();
            }
            return View(casTody);
        }

        // POST: ACasTodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CasTody casTody = db.CasTodies.Find(id);
            db.CasTodies.Remove(casTody);
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
