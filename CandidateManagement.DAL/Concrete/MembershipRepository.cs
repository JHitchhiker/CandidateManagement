using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class MembershipRepository : LookupRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(CMContext context)
            : base(context)
        {
        }
    }
}
