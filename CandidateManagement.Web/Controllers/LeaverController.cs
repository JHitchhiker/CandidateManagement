using CandidateManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Controllers
{
    [Authorize(Roles = "Admin,Reader")]
    public class LeaverController : Controller
    {
        ILeaverService _service;

        public LeaverController(ILeaverService service)
        {
            _service = service;
        }
        // GET: Leaver
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Reader, Update")]
        public ActionResult Leavers()
        {
            return View();
        }
        public JsonResult GetLeavers()
        {
            var model = _service.Get()
                                .Select(a => new { a.Id, a.Interviewee.FirstName, a.Interviewee.Surname, a.LeavingDate })
                                .OrderByDescending(o => o.LeavingDate);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}