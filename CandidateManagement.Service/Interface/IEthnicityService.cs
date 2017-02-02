using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IEthnicityService
    {
        IEnumerable<Ethnicity> GetAll();
        Ethnicity GetById(Int32 id);
        void Create(Ethnicity entity);
        void Update(Ethnicity entity);
        void Delete(Int32 id);
    }
}
