namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Blackboard.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Blackboard.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blackboard.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddLecturer(context);
            AddStudents(context);
        }

        bool AddLecturer(Blackboard.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Lecturer"));

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "Lecturer@email.com",
            };

            ir = um.Create(user, "password");

            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }

            ir = um.AddToRole(user.Id, "Lecturer");
            return ir.Succeeded;
        }
        /*bool AddStudent(Blackboard.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Student"));

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "Student1@email.com",
            };

            ir = um.Create(user, "password");

            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }

            ir = um.AddToRole(user.Id, "Student");
            return ir.Succeeded;
        }*/
        void AddStudents(Blackboard.Models.ApplicationDbContext context)
        {

            var user = new Models.ApplicationUser
            {
                UserName = "student@email.com"
            };
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            um.Create(user, "password");

            var user2 = new Models.ApplicationUser
            {
                UserName = "student2@email.com"
            };
            var um2 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            um2.Create(user2, "password");

            var user3 = new Models.ApplicationUser
            {
                UserName = "student3@email.com"
            };
            var um3 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            um3.Create(user3, "password");

            var user4 = new Models.ApplicationUser
            {
                UserName = "student4@email.com"
            };
            var um4 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            um4.Create(user4, "password");

            var user5 = new Models.ApplicationUser
            {
                UserName = "student5@email.com"
            };
            var um5 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            um5.Create(user5, "password");
        }
    }
}
