using CandidateManagement.Data.Migrations;
using CandidateManagement.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Context
{
    public class CMContext : DbContext
    {
        public CMContext()
            : base("CMContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CMContext, Configuration>());
            //Database.SetInitializer<CMContext>(new CreateDatabaseIfNotExists<CMContext>());
            //Database.SetInitializer<CMContext>(new DropCreateDatabaseIfModelChanges<CMContext>());
        }

        public DbSet<BiteService> BiteServices { get; set; } 
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Interviewee> Interviewees { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Originator> Originators { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<VisaType> VisaTypes { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Leaver> Leavers { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<LeavingReason> LeavingReasons { get; set; }
    }
}
