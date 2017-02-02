using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Models
{
    public abstract class LookupBaseModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
