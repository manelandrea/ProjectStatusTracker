using ProjectStatusTracker.Domain;
using ProjectStatusTracker.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectStatusTracker.Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectDataSource _db;

        public ProjectController(IProjectDataSource db)
        {
            _db = db;
        }
        public ActionResult Detail(int id)
        {
            var username = User.Identity.Name;
           // var bugCases = _db.BugCases.Where(b => b.AssignedTo == username);
            var model = _db.Projects.Single(d => d.Id == id);
            ViewBag.BugCaseList = model.BugCases.Where(b => b.AssignedTo == username);
            return View(model);
        }
    }
}