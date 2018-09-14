using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers
{
    public class GLAccountsController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: GLAccounts
        public ActionResult Index()
        {
            return View(db.GLAccounts.ToList());
        }

        // GET: GLAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GLAccount gLAccount = db.GLAccounts.Find(id);
            if (gLAccount == null)
            {
                return HttpNotFound();
            }
            return View(gLAccount);
        }

        // GET: GLAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GLAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GLAccId,AccType,AccId,GlCreditor,GLDebit,DateCreated,IsDeleted")] GLAccount gLAccount)
        {
            if (ModelState.IsValid)
            {
                db.GLAccounts.Add(gLAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gLAccount);
        }

        // GET: GLAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GLAccount gLAccount = db.GLAccounts.Find(id);
            if (gLAccount == null)
            {
                return HttpNotFound();
            }
            return View(gLAccount);
        }

        // POST: GLAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GLAccId,AccType,AccId,GlCreditor,GLDebit,DateCreated,IsDeleted")] GLAccount gLAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gLAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gLAccount);
        }

        // GET: GLAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GLAccount gLAccount = db.GLAccounts.Find(id);
            if (gLAccount == null)
            {
                return HttpNotFound();
            }
            return View(gLAccount);
        }

        // POST: GLAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GLAccount gLAccount = db.GLAccounts.Find(id);
            db.GLAccounts.Remove(gLAccount);
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
