using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface IOutcomeService
    {

        IEnumerable<Outcome> GetAll();
        Outcome GetById(Int32 id);

        void Create(Outcome entity);
        void Update(Outcome entity);
        void Delete(Int32 id);
    }
}
