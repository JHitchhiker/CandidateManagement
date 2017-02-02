using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IInterviewerService
    {
        IEnumerable<Interviewer> GetAll();
        Interviewer GetById(Int32 id);
        void Create(Interviewer entity);
        void Update(Interviewer entity);
        void Delete(Int32 id);
    }
}
