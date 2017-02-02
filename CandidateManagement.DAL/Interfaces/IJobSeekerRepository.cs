using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public interface IJobSeekerRepository : IBaseRepository<JobSeeker>
    {
        List<JobSeeker> GetByName(string name);
        List<JobSeeker> GetBySurname(string surname);
        List<JobSeeker> GetByNameSurname(string name, string surname);
    }
}
