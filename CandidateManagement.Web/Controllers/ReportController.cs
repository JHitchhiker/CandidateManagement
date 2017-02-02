using CandidateManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    [Authorize(Roles = "Admin,Reader,Update")]
    public class ReportController : Controller
    {
        IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        #region Closure Ratew
        public ActionResult OriginatorClosureRates()
        {
            return View();
        }
        public JsonResult GetOriginatorClosureRates()
        {
            var result = _service.OriginatorClosures();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InterviewerOutcomes()
        {
            return View();
        }
        public JsonResult GetInterviewerClosures()
        {
            var result = _service.InterviewerClosures();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OutcomeByMonth()
        {
            return View();
        }
        public JsonResult GetOutcomeByMonth()
        {
            var result = _service.OutcomesByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OutcomeYTD()
        {
            return View();
        }
        public JsonResult GetOutcomeYTD()
        {
            var result = _service.OutcomeYTD();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Stats by Source


        public ActionResult OutcomeByOriginMonth()
        {
            return View();
        }
        public ActionResult OriginByMonth()
        {
            return View();
        }
        public ActionResult OriginSignupByMonth()
        {
            return View();
        }
        #endregion
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IntervieweesBySourceByMonth()
        {
            return View();
        }
        public ActionResult IntervieweesByVisaByMonth()
        {
            return View();
        }
        
        public ActionResult OutcomeByInterviewer()
        {
            return View();
        }
        public ActionResult OutcomeByOriginator()
        {
            return View();
        }
        
        public ActionResult WorkingByWeek()
        {
            return View();
        }
        public ActionResult WorkingByMonth()
        {
            return View();
        }
        
        public ActionResult ConversionByMonth()
        {
            return View();
        }
        public ActionResult AnnualSignups()
        {
            return View();
        }
        public ActionResult ReportLayout()
        {
            return View();
        }

        
        public JsonResult GetConversionByMonth()
        {
            var result = _service.ConversionsByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAnnualSignups()
        {
            var result = _service.AnnualSignUps();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIntervieweesBySourceByMonth()
        {
            var result = _service.IntervieweesBySourceByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIntervieweesByVisaByMonth()
        {
            var result = _service.IntervieweesByVisaByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetOutcomeByOriginMonth()
        {
            var result = _service.OutcomeByOriginMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOriginByMonth()
        {
            var result = _service.OriginsByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOriginByMonthChart()
        {
            var result = _service.OriginsByMonth().Where(e => e.Origin != "Total");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOriginSignupbyMonth()
        {
            var result = _service.OriginSignUpByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOriginSignupbyMonthChart()
        {
            var result = _service.OriginSignUpByMonth().Where(e => e.Origin != "Total");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOriginatorOutcome()
        {
            var result = _service.OutcomeByOriginator();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWorkingByWeek()
        {
            var result = _service.WorkingTotalByWeek();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWorkingByMonth()
        {
            var result = _service.WorkingTotalByMonth();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetInterviewerOutcomes()
        {
            var result = _service.InterviewerOutcomes();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDashboard()
        {
            var result = _service.DashboardStats();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}