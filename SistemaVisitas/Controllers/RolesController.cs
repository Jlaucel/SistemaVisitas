using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVisitas.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SistemaVisitas.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Roles
        [Authorize]
        public ActionResult Index()
        {
            return View(context.Roles.ToList());
        }
        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {

            try
            {
                context.Roles.Add(new IdentityRole()
                {


                    Name = collection["RoleName"]


                });
                context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return View("Create");

            }
            catch {
                return View();
            }

        }

        public ActionResult Delete(string RoleName) {

            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Create");

        }

        [Authorize]
        public ActionResult ManageUsers() {

            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(String UserName, String RoleName) {



            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).First();
            manager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Role created";

            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem
            {
                Value = rr.Name.ToString(),
                Text = rr.Name
            }).ToList();
            ViewBag.Roles = list;

            return View("ManageUsers");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName) {

            if (!string.IsNullOrWhiteSpace(UserName)){

                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

                ViewBag.RolesForThisUser = manager.GetRoles(user.Id);


                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem
                {

                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }).ToList();
                ViewBag.Roles  = list;

            }
            return View("ManageUsers");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName) {

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            
            if (manager.IsInRole(user.Id, RoleName))
            {
                manager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully";

            }
            else
            {
                ViewBag.ResultMessage = "This user doesnt belong to this role";
            }

            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem
            {

                Value = rr.Name.ToString(),
                Text = rr.Name
            }).ToList();
            ViewBag.Roles = list;

            return View("ManageUsers");
        }


    }
}