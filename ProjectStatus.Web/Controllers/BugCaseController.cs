using ProjectStatusTracker.Domain;
using ProjectStatusTracker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ProjectStatusTracker.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BugCaseController : Controller
    {
        private readonly IProjectDataSource _db;

        public BugCaseController(IProjectDataSource db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Create(int projectId)
        {
            var model = new CreateBugCasesViewModel();
            model.ProjectId = projectId;

            var context = new UsersContext();
            var users = context.UserProfiles.ToList();
            var username = User.Identity.Name;
            var user = context.UserProfiles.SingleOrDefault(u => u.UserName == username);
            users.Remove(user);
            ViewBag.ProfileId = new SelectList(users, "Username", "Username");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBugCasesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var project = _db.Projects.Single(d => d.Id == viewModel.ProjectId);
                var bugCase = new BugCase();
                bugCase.TaskTitle = viewModel.TaskTitle;
                bugCase.TaskDetails = viewModel.TaskDetails;
                bugCase.PercentStatus = viewModel.PercentStatus;
                bugCase.StartDate = viewModel.StartDate;
                bugCase.ProjectedNoOfHours = viewModel.ProjectedNoOfHours;
                bugCase.ProjectedCompletionDate = viewModel.ProjectedCompletionDate;
                bugCase.CompletionDate = viewModel.CompletionDate;
                bugCase.ActualNoOfHours = viewModel.ActualNoOfHours;
                bugCase.IssuesOrRemarks = viewModel.IssuesOrRemarks;
                bugCase.AssignedTo = viewModel.AssignedTo;

                var username = User.Identity.Name;

                bugCase.AssignedBy = username.ToString();
                project.BugCases.Add(bugCase);

                _db.Save();

                return RedirectToAction("detail", "project", new { id = viewModel.ProjectId });
            }
            return View(viewModel);
        }
    }
}