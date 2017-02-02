using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IJobSeekerService
    {
        void Create(JobSeeker entity);
        List<JobSeeker> Get();
        JobSeeker GetById(int id);
        List<JobSeeker> GetCurrent();
        List<JobSeeker> Get65Days();
        JobSeeker GetCurrentRecordIntervieweeId(int id);
        List<JobSeeker> GetByName(string name);
        List<JobSeeker> GetBySurname(string surname);
        List<JobSeeker> GetByNameSurname(string name, string surname);
        void Update(JobSeeker entity);
        void Delete(JobSeeker entity);
    }
}
