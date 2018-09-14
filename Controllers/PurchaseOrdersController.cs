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

using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers
{
    public class PurchaseOrdersController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: api/PurchaseOrders
        [Route("api/order/all")]
        public IQueryable<PurchaseOrder> GetPurchaseOrders()
        {
            return db.PurchaseOrders.AsQueryable().Include(x=>x.Supplier);
        }

        [HttpGet]
        public int NewId()
        {

            var count = 0;
            var temp = db.PurchaseOrders;

            if (temp.Count() == 0)
            {
                count = 1;
            }
            else
            {
                count = temp.Max(x => x.OrderId) + 1;
            }
            return count;
        }
        // GET: api/PurchaseOrders/5
    [Route("api/order/{id}")]
        [ResponseType(typeof(PurchaseOrder))]
        public PurchaseOrder GetPurchaseOrder(int id)
        {
            var purchaseOrder = db.
                PurchaseOrders.Include(x => x.PurchaseOrdersDetails)
                .Include(x=>x.PurchaseOrdersDetails.Select(s=>s.Item))
                .Include(x => x.Employee)
                .Include(x => x.Supplier)
                .Where(x => x.OrderId == id).FirstOrDefault();


            return purchaseOrder;
        }
        // this is defualt Scaffold
        //public async Task<IHttpActionResult> GetPurchaseOrder(int id)
        //{
        //    PurchaseOrder purchaseOrder = await db.PurchaseOrders.FindAsync(id);
        //    if (purchaseOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(purchaseOrder);
        //}

        // PUT: api/PurchaseOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchaseOrder(int id, PurchaseOrder purchaseOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseOrder.OrderId)
            {
                return BadRequest();
            }

            db.Entry(purchaseOrder).State = EntityState.Modified;
            foreach (var item in purchaseOrder.PurchaseOrdersDetails)
            {
                PurchaseOrdersDetail pod  = new PurchaseOrdersDetail();
                pod = item;
                pod.OrderType = purchaseOrder.OrderType;
                pod.OrderId = purchaseOrder.OrderId;
                pod.Id = purchaseOrder.Id;
                db.Entry(pod).State = EntityState.Modified;
                
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderExists(id))
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

        // POST: api/PurchaseOrders
        [ResponseType(typeof(PurchaseOrder))]
        public async Task<IHttpActionResult> PostPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.OrderDate == null)
            {
                purchaseOrder.OrderDate = DateTime.Now;
            }
            purchaseOrder.EmpId = db.Employees.FirstOrDefault().EmpId;
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (purchaseOrder.OrderId != null && purchaseOrder.OrderType !=null)
            //{
            //    PutPurchaseOrder(purchaseOrder.OrderId, purchaseOrder);
            //}
            //else
            //{
            var temp = db.PurchaseOrders;
            if (temp.Count() < 1)
            {
                purchaseOrder.Id = 1;
                purchaseOrder.OrderId = 1;
            }
            else
            {

                purchaseOrder.Id = temp.Max(x=>x.Id)+1;
                purchaseOrder.OrderId = temp.Max(s => s.OrderId) + 1;
            }
                 db.PurchaseOrders.Add(purchaseOrder);
            foreach (var item in purchaseOrder.PurchaseOrdersDetails)
            {
                PurchaseOrdersDetail pod = new PurchaseOrdersDetail();
                pod = item;
               
                pod.OrderId = purchaseOrder.OrderId;
                pod.Id = purchaseOrder.Id;
                pod.QtyReq = pod.CaseWight - pod.WightEmpty;
                db.Entry(pod).State = EntityState.Added;
            }
            await db.SaveChangesAsync();
            //}

           

            return CreatedAtRoute("DefaultApi", new { id = purchaseOrder.OrderId }, purchaseOrder);
        }

        // DELETE: api/PurchaseOrders/5
        [ResponseType(typeof(PurchaseOrder))]
        public async Task<IHttpActionResult> DeletePurchaseOrder(int id)
        {
            PurchaseOrder purchaseOrder = await db.PurchaseOrders.Where(x => x.OrderId == id).FirstOrDefaultAsync();
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            db.PurchaseOrders.Remove(purchaseOrder);
            await db.SaveChangesAsync();

            return Ok(purchaseOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseOrderExists(int id)
        {
            return db.PurchaseOrders.Count(e => e.OrderId == id) > 0;
        }
    }
}