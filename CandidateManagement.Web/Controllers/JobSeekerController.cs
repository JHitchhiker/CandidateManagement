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
    [Authorize(Roles = "Admin,Reader,Update")]
    public class JobSeekerController : Controller
    {
        IJobSeekerService _service;
        IIntervieweeService _intervieweeService;
        IOutcomeService _outcomeService;
        ILeaverService _leaverService;

        public JobSeekerController(IJobSeekerService service, IIntervieweeService intervieweeService, IOutcomeService outcomeService, ILeaverService leaverService)
        {
            _service = service;
            _intervieweeService = intervieweeService;
            _outcomeService = outcomeService;
            _leaverService = leaverService;
        }
        // GET: JobSeeker
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Reader, Update")]
        public ActionResult JobSeekers()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Update")]
        public ActionResult Convert()
        {
            return View();
        }

        public JsonResult GetJobSeekers()
        {
            var model = _service.GetCurrent()
                                .Select(a => new { a.Id, a.Interviewee.FirstName, a.Interviewee.Surname, a.DateStart});

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCurrentJobSeekers()
        {
            var model = _service.GetCurrent()
                                .Select(a => new { a.Interviewee.Id, a.Interviewee.FirstName, a.Interviewee.Surname, a.DateStart });

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin, Update")]
        public ActionResult Terminate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Terminate(int id, DateTime leaveDate)
        {
            var userid = User.Identity.GetUserId();
            var seeker = _service.GetById(id);
            seeker.DateEnd = DateTime.Today;
            seeker.ChangedBy = userid;
            _service.Update(seeker);

            var leaver = new Leaver { IntervieweeId = seeker.IntervieweeId, LeavingDate = leaveDate, ChangedBy = userid, CreatedBy = userid };
            _leaverService.Create(leaver);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Convert(int id, DateTime startDate, string comments)
        {
            if (id == 0)
            {
                return View();
            }
            //update the interviewee to reflect that he is now a job seeker
            var interviewee = _intervieweeService.GetById(id);
            int convertId = _outcomeService.GetAll()
                                           .Where(e => e.Name.ToLower().Contains("convert"))
                                           .Select(s => s.Id)
                                           .FirstOrDefault();

            var userid = User.Identity.GetUserId();
            interviewee.OutcomeId = convertId;
            interviewee.ChangedBy = userid;
            _intervieweeService.Update(interviewee);

            var jobSeeker = new JobSeeker { IntervieweeId = id, DateStart = startDate, ChangedBy = userid, CreatedBy = userid };
            //create the job seeker record
            _service.Create(jobSeeker);
            return RedirectToAction("Convert");
        }
    }
}