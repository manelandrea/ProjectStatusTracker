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
    public class HomeController : Controller
    {
        private IProjectDataSource _db;

        public HomeController(IProjectDataSource db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var allProjects = _db.Projects;
            return View(allProjects);   
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
