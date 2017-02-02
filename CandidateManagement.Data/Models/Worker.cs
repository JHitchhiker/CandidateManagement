using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Models
{
    public class Worker : BaseModel
    {
        public int IntervieweeId { get; set; }
        public int ContractStatusId { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public bool Agency { get; set; }
        public string AgencyName { get; set; }
        public string Client { get; set; }
        public bool Completed { get; set; }
        public DateTime? TerminationDate { get; set; }

        [ForeignKey("IntervieweeId")]
        public virtual Interviewee Interviewee { get; set; }
    }
}
