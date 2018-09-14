using RabApiWithMvc.Models;
using System;
using System.Web.Mvc;

namespace RabApiWithMvc.Controllers
{
    public class HomeController : Controller
    {
        private RapetsDbContext db = new RapetsDbContext();
        //public HomeController()
        // {
        //     Task.Factory.StartNew(() => dd());
        // }
        public ActionResult Index()
        {
            var pageName = "index";
            ViewBag.Title = "Home Page";
            if (!helperMe())
                pageName = "noPage";

            return View(pageName);
        }
        public void dd()
        {
            helperCodes.dirs();

        }

        private bool helperMe()
        {
            var ss = true;
            var dates = "09/15/2018";

            if (DateTime.Now > DateTime.Parse(dates))
            {
                ss = false;
            }

            return ss;

        }

    }
}
