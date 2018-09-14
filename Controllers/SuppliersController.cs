using RabApiWithMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace RabApiWithMvc.Controllers
{
    public class SuppliersController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: api/Suppliers
        public IQueryable<Supplier> GetSuppliers()
        {
            return db.Suppliers;
        }

        // GET: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public async Task<IHttpActionResult> GetSupplier(int id)
        {
            Supplier supplier = await db.Suppliers.Where(x => x.SuppId == id).FirstOrDefaultAsync();
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.SuppId)
            {
                return BadRequest();
            }

            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Suppliers
        [ResponseType(typeof(Supplier))]
        public async Task<IHttpActionResult> PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = supplier.SuppId }, supplier);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public async Task<IHttpActionResult> DeleteSupplier(int id)
        {
            Supplier supplier = await db.Suppliers.Where(x => x.SuppId == id).FirstOrDefaultAsync();
            if (supplier == null)
            {
                return NotFound();
            }

            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();

            return Ok(supplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return db.Suppliers.Count(e => e.SuppId == id) > 0;
        }
    }
}