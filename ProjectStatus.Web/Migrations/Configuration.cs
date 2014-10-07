namespace ProjectStatusTracker.Web.Migrations
{
    using ProjectStatusTracker.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectStatusTracker.Web.Infrastructure.ProjectDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjectStatusTracker.Web.Infrastructure.ProjectDb context)
        {
            context.Projects.AddOrUpdate(p => p.ProjectName,
                    new Project() { ProjectName = "Veolia" },
                    new Project() { ProjectName = "Harbour" },
                    new Project() { ProjectName = "RegentCo" }
                );
            //if (!Roles.RoleExists("Admin"))
            //{
            //    Roles.CreateRole("Admin");
            //}

            //if (Membership.GetUser("manelc") == null)
            //{
            //    Membership.CreateUser("manelc", "zaq12wsx");
            //    Roles.AddUserToRole("manelc", "Admin");
            //}
            SeedMembership();
        }


        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("tim", false) == null)
            {
                membership.CreateUserAndAccount("tim", "password123");
            }
            if (!roles.GetRolesForUser("tim").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "tim" }, new[] { "admin" });
            }
        }
    }
}
