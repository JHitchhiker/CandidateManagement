using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class IntervieweeRepository : BaseRepository<Interviewee>, IIntervieweeRepository
    {
        public IntervieweeRepository(CMContext dataContext)
            : base(dataContext)
        {
        }
        public List<Interviewee> GetByName(string name)
        {
            return context.Interviewees
                          .Where(e => e.FirstName == name)
                          .ToList();
        }
        public List<Interviewee> GetBySurname(string surname)
        {
            return context.Interviewees
                          .Where(e => e.Surname == surname)
                          .ToList();
        }
        public List<Interviewee> GetByNameSurname(string name, string surname)
        {
            return context.Interviewees
                          .Where(e => e.Surname == surname
                                   && e.FirstName == name)
                          .ToList();
        }
    }
}
