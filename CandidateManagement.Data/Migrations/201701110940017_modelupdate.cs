namespace CandidateManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BiteServices", "CreatedBy", c => c.String());
            AlterColumn("dbo.BiteServices", "ChangedBy", c => c.String());
            AlterColumn("dbo.ContractStatus", "CreatedBy", c => c.String());
            AlterColumn("dbo.ContractStatus", "ChangedBy", c => c.String());
            AlterColumn("dbo.Ethnicities", "CreatedBy", c => c.String());
            AlterColumn("dbo.Ethnicities", "ChangedBy", c => c.String());
            AlterColumn("dbo.FinancialYears", "CreatedBy", c => c.String());
            AlterColumn("dbo.FinancialYears", "ChangedBy", c => c.String());
            AlterColumn("dbo.Interviewees", "CreatedBy", c => c.String());
            AlterColumn("dbo.Interviewees", "ChangedBy", c => c.String());
            AlterColumn("dbo.Interviewers", "CreatedBy", c => c.String());
            AlterColumn("dbo.Interviewers", "ChangedBy", c => c.String());
            AlterColumn("dbo.Origins", "CreatedBy", c => c.String());
            AlterColumn("dbo.Origins", "ChangedBy", c => c.String());
            AlterColumn("dbo.Originators", "CreatedBy", c => c.String());
            AlterColumn("dbo.Originators", "ChangedBy", c => c.String());
            AlterColumn("dbo.Outcomes", "CreatedBy", c => c.String());
            AlterColumn("dbo.Outcomes", "ChangedBy", c => c.String());
            AlterColumn("dbo.Professions", "CreatedBy", c => c.String());
            AlterColumn("dbo.Professions", "ChangedBy", c => c.String());
            AlterColumn("dbo.Skills", "CreatedBy", c => c.String());
            AlterColumn("dbo.Skills", "ChangedBy", c => c.String());
            AlterColumn("dbo.VisaTypes", "CreatedBy", c => c.String());
            AlterColumn("dbo.VisaTypes", "ChangedBy", c => c.String());
            AlterColumn("dbo.JobSeekers", "CreatedBy", c => c.String());
            AlterColumn("dbo.JobSeekers", "ChangedBy", c => c.String());
            AlterColumn("dbo.Leavers", "CreatedBy", c => c.String());
            AlterColumn("dbo.Leavers", "ChangedBy", c => c.String());
            AlterColumn("dbo.Memberships", "CreatedBy", c => c.String());
            AlterColumn("dbo.Memberships", "ChangedBy", c => c.String());
            AlterColumn("dbo.Workers", "CreatedBy", c => c.String());
            AlterColumn("dbo.Workers", "ChangedBy", c => c.String());
            
        }
        
        public override void Down()
        {
            
            
            AlterColumn("dbo.Workers", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Workers", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Memberships", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Memberships", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Leavers", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Leavers", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.JobSeekers", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.JobSeekers", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.VisaTypes", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.VisaTypes", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Skills", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Skills", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Professions", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Professions", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Outcomes", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Outcomes", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Originators", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Originators", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Origins", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Origins", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Interviewers", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Interviewers", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Interviewees", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Interviewees", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.FinancialYears", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.FinancialYears", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Ethnicities", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Ethnicities", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ContractStatus", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ContractStatus", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.BiteServices", "ChangedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.BiteServices", "CreatedBy", c => c.Int(nullable: false));
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.Users", "Username", unique: true);
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
