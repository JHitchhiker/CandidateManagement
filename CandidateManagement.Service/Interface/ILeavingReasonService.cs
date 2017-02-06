using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface ILeavingReasonService
    {

        IEnumerable<LeavingReason> GetAll();
        LeavingReason GetById(Int32 id);

        void Create(LeavingReason entity);
        void Update(LeavingReason entity);
        void Delete(Int32 id);
    }
}
