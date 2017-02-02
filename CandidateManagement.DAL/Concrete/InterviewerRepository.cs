using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class InterviewerRepository : LookupRepository<Interviewer>, IInterviewerRepository
    {
        public InterviewerRepository(CMContext context)
            : base(context)
        {
        }
    }
}
