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
    public class AClientsController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: AClients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.Area);
            return View(clients.ToList());
        }



        public ActionResult ClntAcc()
        {
            var clients = db.Clients.Where(d => d.ClntBalance < 0).Include(c => c.Vauchers);
            return View(clients.ToList());
        }

        public ActionResult ViewClintNewPay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Where(i => i.ClntId == id).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }


        // GET: AClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Where(i => i.ClntId == id).Include(d => d.Vauchers).Include(f=>f.SaleOrders).FirstOrDefault() ;
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: AClients/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1");
            return View();
        }

        // POST: AClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClntId,ClntName,Type,fullAddress,OwnerName,PhoneNo,AreaId,ClntDebit,ClntCreditor,ClntBalance,ClntMaxBalance,DateCreated,IsDeleted")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1", client.AreaId);
            return View(client);
        }

        // GET: AClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1", client.AreaId);
            return Redirect("#/clnts");
        }

        // POST: AClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClntId,ClntName,Type,fullAddress,OwnerName,PhoneNo,AreaId,ClntDebit,ClntCreditor,ClntBalance,ClntMaxBalance,DateCreated,IsDeleted")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "Area1", client.AreaId);
            return Redirect("#/clnts");
        }

        // GET: AClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: AClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
