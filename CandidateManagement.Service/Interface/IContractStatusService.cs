using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface IContractStatusService
    {

        IEnumerable<ContractStatus> GetAll();
        ContractStatus GetById(Int32 id);

        void Create(ContractStatus entity);
        void Update(ContractStatus entity);
        void Delete(Int32 id);
    }
}
