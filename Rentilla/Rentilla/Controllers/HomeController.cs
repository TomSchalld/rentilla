using Rentilla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rentilla.Controllers
{
    public class HomeController : Controller
    {
        private InterchangeDBContext db = new InterchangeDBContext();
        private ApplicationDbContext adbc = new ApplicationDbContext();
        public ActionResult Index()
        {

            var lastThreeOffers = (from o in db.Offers
                                    orderby o.ID descending
                                    select o).Take(3);
            var lastThreeDemands = (from d in db.Demands
                                   orderby d.ID descending
                                   select d).Take(3);
            foreach (var item in lastThreeOffers)
            {
                item.UID = (from u in adbc.Users where u.Id.Contains(item.UID) select u.UserName).FirstOrDefault();

                if(item.Description.Length > 10)
                {
                    item.Description = item.Description.Substring(0, 10);
                    item.Description += "...";
                }
            }
            foreach (var item in lastThreeDemands)
            {
                item.UID = (from u in adbc.Users where u.Id.Contains(item.UID) select u.UserName).FirstOrDefault();

                if (item.Description.Length > 10)
                {
                    item.Description = item.Description.Substring(0, 10);
                    item.Description += "...";
                }
            }

            ViewBag.LastThreeOffersList = lastThreeOffers.ToList();
            ViewBag.LastThreeDemandsList = lastThreeDemands.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}