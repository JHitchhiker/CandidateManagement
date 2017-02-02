using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class VisaTypeRepository : LookupRepository<VisaType>, IVisaTypeRepository
    {
        public VisaTypeRepository(CMContext context)
            : base(context)
        {
        }
    }
}
