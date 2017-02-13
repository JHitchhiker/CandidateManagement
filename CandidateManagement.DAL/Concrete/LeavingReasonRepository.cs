using CandidateManagement.Data.Models;
using CandidateManagement.Data.Context;

namespace CandidateManagement.DAL
{
    public class LeavingReasonRepository : LookupRepository<LeavingReason>, ILeavingReasonRepository
    {
        public LeavingReasonRepository(CMContext context)
            : base(context)
        {
        }
    }
}
