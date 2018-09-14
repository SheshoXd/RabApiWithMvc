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
using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers
{
    public class ItemsController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: api/Items
        [HttpGet]
        public IQueryable<Item> GetItems()
        {
            var temp = db.Items
                //.Include(d=>d.StoreItems)
                .Include(u=>u.Uint)
                .ToList();
            //foreach (var item in temp)
            //{
            //    item.AviQty = item.availableQty.ToString();
              
            //}
            return temp.AsQueryable();
        }

        // GET: api/Items/5
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> GetItem(int id)
        {
            Item item = await db.Items.Where(x => x.ItemId == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Items/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ItemId)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> insertItem(Item item)
        {
          var cont =  db.Database.BeginTransaction();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
           
            await db.SaveChangesAsync();
            //StoreItem st = new StoreItem();
            //st.ItemId = item.ItemId;
            //st.availableQty = 0;
            //st.itemQyt = 0;
            //db.Entry(st).State = EntityState.Added;
            //db.StoreItems.Add(st);
            db.SaveChanges();
            cont.Commit();

            
            return CreatedAtRoute("DefaultApi", new { id = item.ItemId }, item);
        }

        // DELETE: api/Items/5
        [ResponseType(typeof(Item))]
        public async Task<IHttpActionResult> DeleteItem(int id)
        {
            Item item = await db.Items.Where(x => x.ItemId == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ItemId == id) > 0;
        }
    }
}