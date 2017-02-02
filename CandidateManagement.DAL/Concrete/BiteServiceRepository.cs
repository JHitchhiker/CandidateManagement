using CandidateManagement.Data.Models;
using CandidateManagement.Data.Context;

namespace CandidateManagement.DAL
{
    public class BiteServiceRepository : LookupRepository<BiteService>, IBiteServiceRepository
    {
        public BiteServiceRepository(CMContext context)
            : base(context)
        {
        }
    }
}
