using CandidateManagement.Data.Models;
using CandidateManagement.Service;
using CandidateManagement.Web.Extensions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    
    public class IntervieweeController : Controller
    {
        IIntervieweeService _service;
        public IntervieweeController(IIntervieweeService service)
        {
            _service = service;
        }

        [Authorize(Roles ="Admin,Reader,Update")]
        public ActionResult Interviewees()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Reader, Update")]
        public ActionResult Details(Int32 id)
        {
            Interviewee model = _service.GetById(id);
            return View(model);
        }
        [CustomAuthorize(Roles = "Admin, Update")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Interviewee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.ChangedBy = User.Identity.GetUserId();
            model.CreatedBy = User.Identity.GetUserId();
            _service.Create(model);
            return RedirectToAction("Interviewees");
        }

        [Authorize(Roles = "Admin, Update")]
        public ActionResult Update(Int32 id)
        {
            
            Interviewee model = _service.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Interviewee model)
        {
            string msg;

            try
            {
                if (ModelState.IsValid)
                {
                    model.ChangedBy = User.Identity.GetUserId();
                    _service.Update(model);
                    msg = "Saved Successfully";
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return RedirectToAction("Interviewees");
        }

        public JsonResult GetInterviewees()
        {
            var model = _service.Get()
                                .Select(a => new { a.Id, a.FirstName, a.Surname, a.InterviewDate, a.Outcome.Description, Originator = a.Originator.Name, Interviewer = a.Interviewer.Name })
                                .OrderByDescending(o => o.InterviewDate);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSignedUp()
        {
            var model = _service.GetSignedUp()
                                .Select(a => new { a.Id, a.FirstName, a.Surname, a.InterviewDate, a.Visa.Description });

            return Json(model, JsonRequestBehavior.AllowGet);
            }
    }
}