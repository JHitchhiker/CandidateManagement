using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class ContractStatusRepository : LookupRepository<ContractStatus>, IContractStatusRepository
    {
        public ContractStatusRepository(CMContext context)
            : base(context)
        {
        }
    }
}
