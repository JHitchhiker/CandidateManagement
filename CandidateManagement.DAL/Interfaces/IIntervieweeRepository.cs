using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public interface IIntervieweeRepository : IBaseRepository<Interviewee>
    {
        List<Interviewee> GetByName(string name);
        List<Interviewee> GetBySurname(string surname);
        List<Interviewee> GetByNameSurname(string name, string surname);

    }
}
