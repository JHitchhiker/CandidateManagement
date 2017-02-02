using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Models
{
    public class Interviewee : BaseModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Visa Status")]
        public int VisaTypeId { get; set; }
        [Required]
        [Display(Name = "Ethnicity")]
        public int EthnicityId { get; set; }
        [Display(Name = "Bite Service")]
        public int? ServiceId { get; set; }
        [Required]
        [Display(Name = "Origin")]
        public int OriginId { get; set; }
        [Required]
        [Display(Name = "Originator")]
        public int OriginatorId { get; set; }
        [Display(Name = "Profession")]
        public int ProfessionId { get; set; }
        [Display(Name = "Skills")]
        public int? SkillId { get; set; }
        [Required]
        [Display(Name = "Interviewer")]
        public int InterviewerId { get; set; }
        [Display(Name = "Interview Date")]
        [Required]
        public DateTime InterviewDate { get; set; }
        [Required]
        [Display(Name = "Outcome")]
        public int OutcomeId { get; set; }
        [Display(Name = "Signup Date")]
        public DateTime? SignUpDate { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }

        [ForeignKey("OutcomeId")]
        public virtual Outcome Outcome { get; set; }
        [ForeignKey("ServiceId")]
        public virtual BiteService BiteService { get; set; }
        [ForeignKey("VisaTypeId")]
        public virtual VisaType Visa { get; set; }

        [ForeignKey("OriginId")]
        public virtual Origin Origin { get; set; }

        [ForeignKey("OriginatorId")]
        public virtual Originator Originator { get; set; }

        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }

        [ForeignKey("InterviewerId")]
        public virtual Interviewer Interviewer { get; set; }
    }
}
