using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class InterviewerService : IInterviewerService
    {
        IInterviewerRepository repository;

        public InterviewerService(IInterviewerRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Interviewer> GetAll()
        {
            return repository.Get();
        }

        public Interviewer GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Interviewer entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Interviewer entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
