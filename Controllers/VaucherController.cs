using RabApiWithMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RabApiWithMvc.Content
{
    public class VaucherController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();
        // GET: api/Vaucher
        public IQueryable<Vaucher> Get()
        {
            return db.Vauchers;
        }

        // GET: api/Vaucher/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vaucher
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vaucher/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vaucher/5
        public void Delete(int id)
        {
        }
    }
}
