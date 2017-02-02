using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Models
{
    public class JobSeeker : BaseModel
    {
        public int IntervieweeId { get; set; }
        [Required]
        [Display(Name="Start Date")]
        public DateTime DateStart { get; set; }
        [Display(Name ="End Date")]
        public DateTime? DateEnd { get; set; }
        public string Comments { get; set; }

        [ForeignKey("IntervieweeId")]
        public virtual Interviewee Interviewee { get; set; }
    }
}
