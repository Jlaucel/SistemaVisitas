using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVisitas.Controllers
{
    public class MembersController : Controller
    {
        [Authorize]
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }
    }
}