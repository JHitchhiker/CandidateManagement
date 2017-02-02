using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class JobSeekerRepository : BaseRepository<JobSeeker>, IJobSeekerRepository
    {
        public JobSeekerRepository(CMContext dataContext)
            : base(dataContext)
        {
        }
        public List<JobSeeker> GetByName(string name)
        {
            return context.JobSeekers
                          .Where(e => e.Interviewee.FirstName == name)
                          .ToList();
        }
        public List<JobSeeker> GetBySurname(string surname)
        {
            return context.JobSeekers
                          .Where(e => e.Interviewee.Surname == surname)
                          .ToList();
        }
        public List<JobSeeker> GetByNameSurname(string name, string surname)
        {
            return context.JobSeekers
                          .Where(e => e.Interviewee.Surname == surname
                                   && e.Interviewee.FirstName == name)
                          .ToList();
        }
    }
}
