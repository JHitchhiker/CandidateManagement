using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IBiteServiceService
    {
        IEnumerable<BiteService> GetAll();
        BiteService GetById(Int32 id);
        void Create(BiteService entity);
        void Update(BiteService entity);
        void Delete(Int32 id);
    }
}
