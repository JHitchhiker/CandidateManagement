using CandidateManagement.Data;
using CandidateManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        SecurityContext context;
        // GET: User
        public ActionResult Users()
        {
            return View();
        }

        public JsonResult GetUsers()
        {
            context = new SecurityContext();
            var users = context.Users.ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void UpdateRoles(string userid, RoleEnableViewModel model)
        {
            try
            {
                SecurityContext context = new SecurityContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

                if (model.Enabled)
                {
                    userManager.AddToRole(userid, model.Name);
                }
                else
                {
                    userManager.RemoveFromRole(userid, model.Name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}