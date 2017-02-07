using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.ReportModels
{
    public class OriginatorLeaver
    {
        public string Originator { get; set; }
        public int Terminated { get; set; }
        public int Left { get; set; }
        public int Exception { get; set; }
        public int Permanent { get; set; }
        public int TOTAL { get; set; }
        public decimal PERCENTAGE { get; set; }
    }
}
