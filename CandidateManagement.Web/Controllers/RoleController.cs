using CandidateManagement.Data;
using CandidateManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        public RoleController()
        {
           
        }
        SecurityContext context;
        // GET: Role
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            context = new SecurityContext();
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Create(string name)
        {
            SecurityContext context = new SecurityContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole { Name = name });
        }

        public ActionResult Roles()
        {
            return View();
        }
        public JsonResult GetRoles()
        {
            context = new SecurityContext();
            var Roles = context.Roles.ToList();
            return Json(Roles, JsonRequestBehavior.AllowGet);

            
        }

        public JsonResult GetEnableRoles(string userid)
        {
            if (userid == null || userid == "")
            {
                return null;
            }
            context = new SecurityContext();
            var Roles = context.Roles.Select(item => new RoleEnableViewModel { Id = item.Id, Name = item.Name, Enabled = false }).ToList();
            

            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var user = userManager.Users.Where(e => e.Id == userid);


            foreach (var role in Roles)
            {
                if (user.First().Roles.Any(e=> e.RoleId == role.Id))
                {
                    role.Enabled = true;
                }
            }
            return Json(Roles, JsonRequestBehavior.AllowGet);
        }

        
    }
}