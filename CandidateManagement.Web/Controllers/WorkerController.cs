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
    [Authorize(Roles = "Admin, Reader, Update")]
    public class WorkerController : Controller
    {
        IWorkerService _service;
        IJobSeekerService _jobseekerService;
        ILeaverService _leaverService;
        // GET: Worker
        public WorkerController(IWorkerService service, IJobSeekerService jobseekerService, ILeaverService leaverService)
        {
            _service = service;
            _jobseekerService = jobseekerService;
            _leaverService = leaverService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Workers()
        {
            return View();
        }
        public ActionResult Convert()
        {
            return View();
        }
        public ActionResult FinishingSoon()
        {
            return View();
        }
        public ActionResult OutOfContract()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Update")]
        public ActionResult Terminate()
        {
            return View();
        }

        
        public JsonResult GetWorkers()
        {
            var model = _service.GetCurrent()
                                .Select(a => new { a.Id, a.Interviewee.FirstName, a.Interviewee.Surname, a.ContractStart,a.ContractEnd, a.Client });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWorkerById(int id)
        {
            var model = _service.GetById(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void TerminateWorker(int id, DateTime terminateDate, bool leaver, int leavingReasonId)
        {
            if (!leaver)
            {
                var worker = _service.GetById(id);
                worker.TerminationDate = terminateDate;
                worker.Completed = true;
                _service.Update(worker);

                var jobseeker = new JobSeeker { IntervieweeId = worker.IntervieweeId, DateStart = terminateDate };
                _jobseekerService.Create(jobseeker);
            }
            else
            {
                var worker = _service.GetById(id);
                worker.TerminationDate = terminateDate;
                worker.Completed = true;
                _service.Update(worker);

                var leave = new Leaver { IntervieweeId = worker.IntervieweeId, LeavingDate = terminateDate, LeavingReasonId = leavingReasonId };
                _leaverService.Create(leave);
            }
        }


        [HttpPost]
        public ActionResult Convert(int id, int contractStatus, DateTime startDate, DateTime endDate, string agencyName, string clientName, string comments)
        {
            if (id == 0)
            {
                return View();
            }
            var userid = User.Identity.GetUserId();

            //update the interviewee to reflect that he is now a job seeker
            var jobSeeker = _jobseekerService.GetCurrentRecordIntervieweeId(id);
            jobSeeker.DateEnd = DateTime.Today;
            jobSeeker.ChangedBy = userid;
            _jobseekerService.Update(jobSeeker);

            var worker = new Worker
            {
                IntervieweeId = id,
                AgencyName = agencyName,
                Client = clientName,
                ContractStart = startDate,
                ContractEnd = endDate,
                ContractStatusId = contractStatus,
                CreatedBy = userid,
                ChangedBy = userid
            };
            _service.Create(worker);
            return RedirectToAction("Convert");
        }
        [HttpPost]
        public void ConvertToJobSeeker(int id, DateTime startDate)
        {
            
            if (startDate == null)
            {
                startDate = DateTime.Today;
            }
            
            var worker = _service.GetById(id);

            var exists = _jobseekerService.Get()
                                          .Where(e => e.IntervieweeId == worker.IntervieweeId
                                                   && e.DateEnd == null)
                                          .Any();
            if (!exists)
            {
                var userid = User.Identity.GetUserId();

                worker.Completed = true;
                worker.ChangedBy = userid;
                _service.Update(worker);

                var jobseeker = new JobSeeker { IntervieweeId = worker.IntervieweeId, DateStart = startDate, CreatedBy = userid, ChangedBy = userid };
                _jobseekerService.Create(jobseeker);
            }
        }
        [HttpPost]
        public void ConvertToLeaver(int id, DateTime finishDate, int leavingReasonId)
        {
            if (finishDate == null)
            {
                finishDate = DateTime.Today;
            }
            var userid = User.Identity.GetUserId();
            var worker = _service.GetById(id);

            var leaver = new Leaver { IntervieweeId = worker.IntervieweeId, LeavingDate = finishDate, CreatedBy = userid, ChangedBy = userid, LeavingReasonId = leavingReasonId };
            _leaverService.Create(leaver);

            worker.Completed = true;
            worker.ChangedBy = userid;
            _service.Update(worker);
            
        }

        public void RenewContract(int id, DateTime startDate, DateTime endDate, int contractStatus)
        {
            if (startDate == null
                || endDate == null
                || contractStatus == 0)
            {
                return;
            }
            var userid = User.Identity.GetUserId();

            var worker = _service.GetById(id);
            worker.Completed = true;
            worker.ChangedBy = userid;
            _service.Update(worker);

            var newContract = new Worker
            {
                IntervieweeId = worker.IntervieweeId,
                ContractStart = startDate,
                ContractEnd = endDate,
                Client = worker.Client,
                AgencyName = worker.AgencyName,
                ContractStatusId = contractStatus,
                CreatedBy = userid,
                ChangedBy = userid
            };
            _service.Create(newContract);

            RedirectToAction("Index");
        }

        public void CompleteWorker(int id)
        {
            var worker = _service.GetById(id);
            worker.Completed = true;
            worker.ChangedBy = User.Identity.GetUserId();
            _service.Update(worker);
        }
        public JsonResult GetFinishingSoon()
        {
            var model = _service.GetFinishingSoon()
                                .Select(a => new { a.Id, a.Interviewee.FirstName, a.Interviewee.Surname, a.ContractEnd });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOutOfContract()
        {
            var model = _service.GetOutOfContract()
                                .Select(a => new { a.Id, a.Interviewee.FirstName, a.Interviewee.Surname, a.ContractEnd });
            
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}