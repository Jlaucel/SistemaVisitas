using SistemaVisitas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVisitas.Controllers
{

    public class HomeController : Controller
    {
        SistemaVisitasEntitites db = new SistemaVisitasEntitites();

        [Authorize]
        public ActionResult Index()
        {

            var items = db.REGISTROVISITAS.ToList();

            var lastVisit = db.REGISTROVISITAS.OrderByDescending(a => a.FECHA).FirstOrDefault();

            
            List<DateTime> x = new List<DateTime>();

            List<DateTime> listtoremove = new List<DateTime>();

            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 07, 30, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 13, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 00, 00));

            foreach (var a in x) {

                if (a < lastVisit.FECHA) {
                    listtoremove.Add(a);
                }
                    
            }

            x.RemoveAll(a => listtoremove.Contains(a));
            

            ViewBag.HoursToVisit = x;

            return View(items);
        }
        [Authorize(Roles =("Admin,Developer"))]
        public ActionResult Stadistics() {

            var items = db.REGISTROVISITAS.ToList();

            return View(items);
        }

      
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}