using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.ReportModels
{
    public class WorkingTotalByMonth
    {
        public string Month { get; set; }
        public int JobSeekers { get; set; }
        public int Working { get; set; }
        public int Leavers { get; set; }
        public int ContractsEnding { get; set; }
        public int NewContracts { get; set; }
        public int ContractsExtending { get; set; }
    }
}
