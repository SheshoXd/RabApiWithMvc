using RabApiWithMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using  RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers
{
    public class ReportsController : ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();
        [Route ("api/Report/GetSealOrder/{from}/{to}/{clintId}")]
        public HttpResponseMessage GetSealOrder(DateTime? from, DateTime? to, int? clintId)
        {
            try
            {
            var TempData = db.SaleOrders.Include(d => d.Client).AsQueryable();
            if (from != null)
            {
                TempData = TempData.Where(d => d.SlOrdDate > from);
            }
            if (to != null)
            {
                TempData = TempData.Where(d => d.SlOrdDate < to);
            }
            if (to != null)
            {
                TempData = TempData.Where(f => f.Client.ClntId == clintId);
            }

         
              
                return Request.CreateResponse(HttpStatusCode.OK, TempData);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);

            }

        }

        private class MyData
        {
            public List<string> labels { get; set; }

            public List<datasets> datasets { get; set; }

        }
        private class datasets
        {

            public List<int> data { get; set; }
            public List<string> backgroundColor { get; set; }
            public List<string> hoverBackgroundColor { get; set; }
        }
         [Route ("api/Report/dds")]
        [HttpGet]
        public HttpResponseMessage tst()
        {
                     MyData data = new MyData();
            data.labels = new List<string>(){ "Symbian", "Blackberry", "Other", "Android", "IOS"};
            datasets datas = new datasets();
             datas.data = new List<int>(){15, 20, 30, 10, 50};
             datas.backgroundColor = new List<string>(){"#BDC3C7", "#9B59B6", "#E74C3C", "#26B99A", "#3498DB"};
             datas.hoverBackgroundColor =  new List<string>(){"#CFD4D8", "#B370CF", "#E95E4F", "#36CAAB", "#49A9EA"};
             List<datasets> lds = new List<datasets>();
             lds.Add(datas);
             data.datasets = lds;

            try
            {
                var TempData = data;
              


                return Request.CreateResponse(HttpStatusCode.OK, TempData);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);

            }

        }




    }
}
