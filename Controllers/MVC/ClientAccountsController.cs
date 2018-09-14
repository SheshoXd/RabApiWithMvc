using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers
{
    public class ClientAccountsController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: ClientAccounts
        public ActionResult Index()
        {
            var clientAccounts = db.ClientAccounts.Include(c => c.Client);
            return View(clientAccounts.ToList());
        }

       
        public ActionResult GetClinteAccounts(int ClientID)
        {

            var ClientAcc = db.ClientAccounts.Where(x => x.ClntAccId == ClientID).ToList();
            return View(ClientAcc.ToList());

        }

        // GET: ClientAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAccount clientAccount = db.ClientAccounts.Find(id);
            if (clientAccount == null)
            {
                return HttpNotFound();
            }
            return View(clientAccount);
        }

        // GET: ClientAccounts/Create
        public ActionResult Create()
        {
            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName");
            return View();
        }

        // POST: ClientAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClntAccId,ClntId,ClntDebit,ClntCreditor,DateCreated,IsDeleted")] ClientAccount clientAccount)
        {
            if (ModelState.IsValid)
            {
                db.ClientAccounts.Add(clientAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName", clientAccount.ClntId);
            return View(clientAccount);
        }

        // GET: ClientAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAccount clientAccount = db.ClientAccounts.Find(id);
            if (clientAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName", clientAccount.ClntId);
            return View(clientAccount);
        }

        // POST: ClientAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClntAccId,ClntId,ClntDebit,ClntCreditor,DateCreated,IsDeleted")] ClientAccount clientAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClntId = new SelectList(db.Clients, "ClntId", "ClntName", clientAccount.ClntId);
            return View(clientAccount);
        }

        // GET: ClientAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientAccount clientAccount = db.ClientAccounts.Find(id);
            if (clientAccount == null)
            {
                return HttpNotFound();
            }
            return View(clientAccount);
        }

        // POST: ClientAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientAccount clientAccount = db.ClientAccounts.Find(id);
            db.ClientAccounts.Remove(clientAccount);
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
