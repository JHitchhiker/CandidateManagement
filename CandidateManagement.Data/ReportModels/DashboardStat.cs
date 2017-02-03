using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.ReportModels
{
    public class DashboardStat
    {
        public decimal Average { get; set; }
        public int Interviews { get; set; }
        public int SignUps { get; set; }
        public int OnContract { get; set; }
        public int NewContracts { get; set; }
        public int EndingSoon { get; set; }
        public decimal DaysToJob { get; set; }
        public decimal SuccessRate { get; set; }
        public int JobSeekers { get; set; }
        public decimal ConversionRate { get; set; }
        public int YTDInterviews { get; set; }
        public int RepeatContractors { get; set; }
        public decimal RepeatRatio { get; set; }
        public int OutOfContract { get; set; }
    }
}
