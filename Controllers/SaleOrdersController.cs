using RabApiWithMvc.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RabApiWithMvc.Controllers
{
    public class SaleOrdersController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: api/SaleOrders
        public List<SaleOrder> GetSaleOrders()
        {

            return db.SaleOrders.Include(x => x.Client).ToList();
        }

        // GET: api/SaleOrders/5
        [ResponseType(typeof(SaleOrder))]
        public async Task<IHttpActionResult> GetSaleOrder(int id)
        {
            SaleOrder saleOrder =
                await db.SaleOrders.Include(x => x.SaleOrdersDetails.Select(xs => xs.Item)).Include(x => x.Client).Include(x => x.Employee).Where(x => x.SlOrdId == id).FirstOrDefaultAsync();
            if (saleOrder == null)
            {
                return NotFound();
            }

            return Ok(saleOrder);
        }

        // PUT: api/SaleOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSaleOrder(int id, SaleOrder saleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saleOrder.SlOrdId)
            {
                return BadRequest();
            }

            db.Entry(saleOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleOrderExists(id))
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
        [HttpGet]
        public int NewNumber()
        {
            int newNum = 1;
            try
            {
                newNum = db.SaleOrders.Max(x => x.SlOrdId) + 1;
            }
            catch
            {

            }
            return newNum;
        }
        // POST: api/SaleOrders
        [ResponseType(typeof(SaleOrder))]
        public async Task<IHttpActionResult> PostSaleOrder(SaleOrder saleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            saleOrder.SlOrdId = NewNumber();
            saleOrder.EmpId = db.Employees.FirstOrDefault().EmpId;
            foreach (var detail in saleOrder.SaleOrdersDetails)
            {
                detail.SlOrdId = saleOrder.SlOrdId;
                detail.SlQty = detail.CaseWight.GetValueOrDefault() - detail.WightEmpty.GetValueOrDefault();
                detail.TotalPrice = detail.ItemPrice.GetValueOrDefault() * detail.SlQty.GetValueOrDefault();

            }
            db.SaleOrders.Add(saleOrder);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SaleOrderExists(saleOrder.SlOrdId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = saleOrder.SlOrdId }, saleOrder);
        }

        // DELETE: api/SaleOrders/5
        [ResponseType(typeof(SaleOrder))]
        public async Task<IHttpActionResult> DeleteSaleOrder(int id)
        {
            SaleOrder saleOrder = await db.SaleOrders.Where(x => x.SlOrdId == id).FirstOrDefaultAsync();
            if (saleOrder == null)
            {
                return NotFound();
            }

            db.SaleOrders.Remove(saleOrder);
            await db.SaveChangesAsync();

            return Ok(saleOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleOrderExists(int id)
        {
            return db.SaleOrders.Count(e => e.SlOrdId == id) > 0;
        }
    }
}