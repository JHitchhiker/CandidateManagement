using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.ReportModels
{
    public class ConversionByMonth
    {
        public string Month { get; set; }
        public int Interviews { get; set; }
        public int JobSeekers { get; set; }
        public decimal JConvert { get; set; }
        public int Workers { get; set; }
        public decimal WConvert { get; set; }
        
    }
}
