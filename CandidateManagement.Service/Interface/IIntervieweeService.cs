using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IIntervieweeService
    {
        void Create(Interviewee entity);
        List<Interviewee> Get();
        Interviewee GetById(int id);
        List<Interviewee> GetSignedUp();
        List<Interviewee> GetByName(string name);
        List<Interviewee> GetBySurname(string surname);
        List<Interviewee> GetByNameSurname(string name, string surname);
        void Update(Interviewee entity);
        void Delete(Interviewee entity);
    }
}
