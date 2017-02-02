using CandidateManagement.Data.Models;
using CandidateManagement.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers.Lookups
{
    [Authorize(Roles = "Admin,Reader,Update")]
    public class EthnicityController : Controller
    {
        IEthnicityService service;

        public EthnicityController(IEthnicityService service)
        {
            this.service = service;
        }
        //
        // GET: /Ethnicity/

        public ActionResult Index()
        {
            var model = service.GetAll().Select(e => new { e.Id, e.Name, e.Description }).ToList();
            return View(model);
        }

        [AllowAnonymous]
        public JsonResult GetEthnicities()
        {
            var model = service.GetAll()
                               .Where(e => e.Active)
                               .Select(a => new { a.Id, a.Name, a.Description });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // TODO:insert a new row to the grid logic here
        [HttpPost]
        public string Create(string name, string description)
        {
            var userid = User.Identity.GetUserId();
            string msg = "";
            try
            {
                service.Create(new Ethnicity { Name = name, Description = description, ChangedBy = userid, CreatedBy = userid });
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        [HttpPost]
        public string Update(int id, string name, string description)
        {
            string msg;
            try
            {
                Ethnicity model = service.GetById(id);
                model.Name = name;
                model.Description = description;
                model.ChangedBy = User.Identity.GetUserId();
                service.Update(model);
                msg = "Saved Successfully";
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(int id)
        {
            service.Delete(id);
            return "Deleted successfully";
        }
    }
}