using CandidateManagement.Data.Models;
using CandidateManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IFinancialYearService _financialYearService;

        public AdminController(IFinancialYearService financialYearService)
        {
            _financialYearService = financialYearService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public void Import()
        {

        }
        public ActionResult CreateUser()
        {
            return View();
        }

     
        public ActionResult FinancialYears()
        {
            return View();
        }

        [HttpPost]
        public void NewFinancialYear(string year, DateTime startDate, DateTime endDate)
        {
            var model = new FinancialYear { Year = year, StartDate = startDate, EndDate = endDate };
            _financialYearService.Create(model);
        }

        public JsonResult GetFinancialYears()
        {
            var model = _financialYearService.Get();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}