using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }
        public DateTime DateChanged { get; set; }
        public bool Active { get; set; }
    }
}
