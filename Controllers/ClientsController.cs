using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RabApiWithMvc.Models;
using RabApiWithMvc.BL;

namespace RabApiWithMvc.Controllers
{
    public class ClientsController : ApiController
    {
        private  RapetsDbContext db = new  RapetsDbContext();
        private ClintesServises RepoClintServ = new ClintesServises();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        public IQueryable<Client> GetClientsAcc()
        {
            var clint = db.Clients.Where(d => d.ClntBalance <0).Include(f=>f.Vauchers).AsQueryable();


            return clint;
        }
     

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await db.Clients.Where(x => x.ClntId == id).FirstOrDefaultAsync();
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpGet]
        public HttpResponseMessage CreateInvoiceVoucher(int id)
        {
            if (id != null)
            {
                try
                {
                    var temp = db.Clients.Where(d => d.ClntId == id).Include(d => d.ClientAccounts).Include(s => s.SaleOrders.Select(x=>x.SaleOrdersDetails)).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, temp);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);

                }

            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "No Data Found");

        }
        [HttpGet]
        public HttpResponseMessage GetClinteDetiles(int id)
        {
            if (id != null)
            {
                try
                {
                    var temp = db.Clients.Where(d => d.ClntId == id).Include(d=>d.ClientAccounts).Include(s=>s.SaleOrders).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, temp);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);

                }

            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "No Data Found");

        }
               [HttpGet]
        public HttpResponseMessage GetClinteSelOrder(int id)
        {
            if (id != null)
            {
                try
                {
                    var temp = db.SaleOrders.Where(d => d.ClntId == id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, temp);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);

                }

            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "No Data Found");

        }
              [HttpGet]
     
        public HttpResponseMessage GetClintesAccount()
        {

            var temp = db.Clients.Include(f => f.ClientAccounts);
                if (temp != null) 
            { 
             try
          
             { 


                return Request.CreateResponse(HttpStatusCode.OK, temp);
             }
            catch (Exception ex)
             {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            
             }
            
            }
            return  Request.CreateResponse(HttpStatusCode.NoContent,"No Data Found" );

        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClntId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public HttpResponseMessage PostClient(Client client)
        {
           
            if (client != null)
            {
                try
                {
                  
                    db.Clients.Add(client);
                    db.Entry(client).State = EntityState.Added;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, client);
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                //catch (Exception ex)
                //{

                //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Happened" + ex.Message);
                //}


      
            }
            else
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "no data sent");
            }
          

           
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client client = await db.Clients.Where(x => x.ClntId == id).FirstOrDefaultAsync();
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClntId == id) > 0;
        }
    }
}