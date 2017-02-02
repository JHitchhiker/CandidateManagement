using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Models
{
    public class Leaver : BaseModel
    {
        public int IntervieweeId { get; set; }
        public DateTime LeavingDate { get; set; }

        [ForeignKey("IntervieweeId")]
        public virtual Interviewee Interviewee { get; set; }
    }
}
