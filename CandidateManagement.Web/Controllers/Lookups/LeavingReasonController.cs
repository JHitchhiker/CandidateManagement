using CandidateManagement.Data.Models;
using CandidateManagement.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeavingReasonController : Controller
    {
        ILeavingReasonService service;

        public LeavingReasonController(ILeavingReasonService service)
        {
            this.service = service;
        }
        
        public ActionResult LeavingReasons()
        {
            return View();
        }
        [AllowAnonymous]
        public JsonResult GetLeavingReasons()
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
                service.Create(new LeavingReason { Name = name, Description = description, CreatedBy = userid, ChangedBy = userid });
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
            var userid = User.Identity.GetUserId();
            string msg;
            try
            {
                LeavingReason model = service.GetById(id);
                model.Name = name;
                model.Description = description;
                model.ChangedBy = userid;
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