using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class EthnicityRepository : LookupRepository<Ethnicity>, IEthnicityRepository
    {
        public EthnicityRepository(CMContext context)
            : base(context)
        {
        }
    }
}
