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
    public class UintsController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();

        // GET: api/Uints
        public IQueryable<Uint> GetUints()
        {
            return db.Uints;
        }

        // GET: api/Uints/5
        [ResponseType(typeof(Uint))]
        public async Task<IHttpActionResult> GetUint(int id)
        {
            Uint @uint = await db.Uints.Where(x=>x.UintId == id).FirstOrDefaultAsync();
            if (@uint == null)
            {
                return NotFound();
            }

            return Ok(@uint);
        }

        // PUT: api/Uints/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUint(int id, Uint @uint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @uint.UintId)
            {
                return BadRequest();
            }

            db.Entry(@uint).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UintExists(id))
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

        // POST: api/Uints
        [ResponseType(typeof(Uint))]
        public async Task<IHttpActionResult> PostUint(Uint @uint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uints.Add(@uint);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UintExists(@uint.UintId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = @uint.UintId }, @uint);
        }

        // DELETE: api/Uints/5
        [ResponseType(typeof(Uint))]
        public async Task<IHttpActionResult> DeleteUint(int id)
        {
            Uint @uint = await db.Uints.Where(x => x.UintId == id).FirstOrDefaultAsync();
            if (@uint == null)
            {
                return NotFound();
            }

            db.Uints.Remove(@uint);
            await db.SaveChangesAsync();

            return Ok(@uint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UintExists(int id)
        {
            return db.Uints.Count(e => e.UintId == id) > 0;
        }
    }
}