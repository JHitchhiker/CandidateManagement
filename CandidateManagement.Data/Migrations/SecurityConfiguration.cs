namespace CandidateManagement.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SecurityConfiguration : DbMigrationsConfiguration<SecurityContext>
    {
        public SecurityConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CandidateManagement.Data.Context.SecurityContext";
        }

        protected override void Seed(SecurityContext context)
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
        }
    }
}
