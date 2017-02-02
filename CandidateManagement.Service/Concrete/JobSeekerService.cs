using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public class JobSeekerService : IJobSeekerService
    {
        IJobSeekerRepository _repository;

        public JobSeekerService(IJobSeekerRepository repository)
        {
            _repository = repository;
        }
        public void Create(JobSeeker entity)
        {
            
            _repository.Insert(entity);
        }
        public List<JobSeeker> Get()
        {
            return _repository.Get().ToList();
        }
        public JobSeeker GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<JobSeeker> Get65Days()
        {
            return _repository.Get()
                              .Where(e => e.Interviewee.BiteService.Description.Contains("65"))
                              .ToList();
        }
        public List<JobSeeker> GetCurrent()
        {
            return _repository.Get()
                              .Where(e => e.DateStart < DateTime.Now 
                                       && e.DateEnd == null)
                              .ToList();
        }
        public JobSeeker GetCurrentRecordIntervieweeId(int id)
        {
            return _repository.Get()
                              .Where(e => e.IntervieweeId == id
                                       && e.DateEnd == null)
                              .FirstOrDefault();
        }
        public List<JobSeeker> GetByName(string name)
        {
            return _repository.GetByName(name);
        }
        public List<JobSeeker> GetBySurname(string surname)
        {
            return _repository.GetBySurname(surname);
        }
        public List<JobSeeker> GetByNameSurname(string name, string surname)
        {
            return _repository.GetByNameSurname(name, surname);
        }
        public void Update(JobSeeker entity)
        {
            _repository.Update(entity);
        }
        public void Delete(JobSeeker entity)
        {
            _repository.Delete(entity);
        }
    }
}
