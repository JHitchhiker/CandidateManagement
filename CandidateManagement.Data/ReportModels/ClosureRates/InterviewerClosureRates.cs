using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.ReportModels
{
    public class InterviewerClosureRates
    {
        public string Interviewer { get; set; }
        public int CXD { get; set; }
        public int Decline { get; set; }
        public int EXPREQ { get; set; }
        public int NOSHOW { get; set; }
        public int NTU { get; set; }
        public int Pending { get; set; }
        public int Reschedule { get; set; }
        public int SIGNEDUP { get; set; }
        public int T2No { get; set; }
        public int T2POTENTIAL { get; set; }
        public int T2Yes { get; set; }
        public int TOTAL { get; set; }
        public decimal PERCENTAGE { get; set; }
        public int NSP { get; set; }
        public decimal SIGNUPPERCENTAGE { get; set; }
    }
}