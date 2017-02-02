using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;

namespace CandidateManagement.DAL
{
    public class OriginRepository : LookupRepository<Origin>, IOriginRepository
    {
        public OriginRepository(CMContext context)
            : base(context)
        {
        }
    }
}
