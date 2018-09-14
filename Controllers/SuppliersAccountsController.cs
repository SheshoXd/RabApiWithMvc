using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers
{
    public class SuppliersAccountsController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: SuppliersAccounts
        public async Task<ActionResult> Index()
        {
            var suppliersAccounts = db.SuppliersAccounts.Include(s => s.Supplier);
            return View(await suppliersAccounts.ToListAsync());
        }

        // GET: SuppliersAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliersAccount suppliersAccount = await db.SuppliersAccounts.Where(x => x.SuppId == id).FirstOrDefaultAsync();
            if (suppliersAccount == null)
            {
                return HttpNotFound();
            }
            return View(suppliersAccount);
        }

        // GET: SuppliersAccounts/Create
        public ActionResult Create()
        {
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName");
            return View();
        }

        // POST: SuppliersAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SuppAccId,SuppId,SuppCreditor,SuppDebit,AccType,IsDeleted,DateCreated")] SuppliersAccount suppliersAccount)
        {
            if (ModelState.IsValid)
            {
                db.SuppliersAccounts.Add(suppliersAccount);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName", suppliersAccount.SuppId);
            return View(suppliersAccount);
        }

        // GET: SuppliersAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliersAccount suppliersAccount = await db.SuppliersAccounts.Where(x => x.SuppId == id).FirstOrDefaultAsync();
            if (suppliersAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName", suppliersAccount.SuppId);
            return View(suppliersAccount);
        }

        // POST: SuppliersAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SuppAccId,SuppId,SuppCreditor,SuppDebit,AccType,IsDeleted,DateCreated")] SuppliersAccount suppliersAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suppliersAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SuppId = new SelectList(db.Suppliers, "SuppId", "SuppName", suppliersAccount.SuppId);
            return View(suppliersAccount);
        }

        // GET: SuppliersAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliersAccount suppliersAccount = await db.SuppliersAccounts.Where(x => x.SuppId == id).FirstOrDefaultAsync();
            if (suppliersAccount == null)
            {
                return HttpNotFound();
            }
            return View(suppliersAccount);
        }

        // POST: SuppliersAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SuppliersAccount suppliersAccount = await db.SuppliersAccounts.Where(x => x.SuppId == id).FirstOrDefaultAsync();
            db.SuppliersAccounts.Remove(suppliersAccount);
            await db.SaveChangesAsync();
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
