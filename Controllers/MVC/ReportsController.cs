using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RabApiWithMvc.Models;

namespace RabApiWithMvc.Controllers.MVC
{
    public class ReportsController : Controller
    {
        RapetsDbContext db = new RapetsDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllSealsOrders(DateTime? from, DateTime? to , int ? clintId)
        
        {
              var TempData = db.SaleOrders.Include(d=>d.Client).AsQueryable();
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
                TempData = TempData.Where(f=>f.Client.ClntId == clintId);
            }

            return View(TempData.AsEnumerable());

        }

    }
}