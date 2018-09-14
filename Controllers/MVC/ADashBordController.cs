using RabApiWithMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RabApiWithMvc.Controllers.MVC
{
    public class ADashBordController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();
        // GET: ADashBord
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
    

        public ActionResult DashBord()
        {
            //labels: [  ],
            //datasets: [{
            //             data: [15, 20, 30, 10, 50],
            //             backgroundColor: ["#BDC3C7", "#9B59B6", "#E74C3C", "#26B99A", "#3498DB"],
            //             hoverBackgroundColor: ["#CFD4D8", "#B370CF", "#E95E4F", "#36CAAB", "#49A9EA"]
            //            }
            //              ]

           var itemsName = db.Items.OrderBy(d => d.ItemId).Take(5).Skip(0).Select(f => f.ItemName).ToList();
            MyData data = new MyData();
            data.labels = itemsName; //new List<string>() { "Symbian", "Blackberry", "Other", "Android", "IOS" };
            datasets datas = new datasets();
            datas.data = new List<int>() { 15, 20, 30, 10, 50 };
            datas.backgroundColor = new List<string>() { "#BDC3C7", "#9B59B6", "#E74C3C", "#26B99A", "#3498DB" };
            datas.hoverBackgroundColor = new List<string>() { "#CFD4D8", "#B370CF", "#E95E4F", "#36CAAB", "#49A9EA" };
            List<datasets> lds = new List<datasets>();
            lds.Add(datas);
            data.datasets = lds;


            ViewBag.tpo = db.PurchaseOrders.Count();
            ViewBag.tso = db.SaleOrders.Count();


            ViewBag.Mydata = data; ;


            return View();
        }

        // GET: ADashBord/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ADashBord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADashBord/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADashBord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ADashBord/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADashBord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ADashBord/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
