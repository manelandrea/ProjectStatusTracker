using ProjectStatusTracker.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectStatusTracker.Web.Infrastructure
{
    public class ProjectDb : DbContext, IProjectDataSource
    {
        public ProjectDb()
            : base("DefaultConnection")
        {

        }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BugCase> BugCases { get; set; }

        void IProjectDataSource.Save()
        {
            SaveChanges();
        }
        //IQueryable<Employee> IProjectDataSource.Employees
        //{
        //    get { return Employees; }
        //}

        IQueryable<BugCase> IProjectDataSource.BugCases
        {
            get { return BugCases; }
        }

        IQueryable<Project> IProjectDataSource.Projects
        {
            get { return Projects; }
        }

        public System.Data.Entity.DbSet<ProjectStatusTracker.Web.Models.CreateBugCasesViewModel> CreateBugCasesViewModels { get; set; }
    }
}