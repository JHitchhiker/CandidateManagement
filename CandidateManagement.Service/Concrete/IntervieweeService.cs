using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class IntervieweeService : IIntervieweeService
    {
        IIntervieweeRepository _repository;

        public IntervieweeService(IIntervieweeRepository repository)
        {
            _repository = repository;
        }
        public void Create(Interviewee entity)
        {
            _repository.Insert(entity);
        }
        public List<Interviewee> Get()
        {
            return _repository.Get().ToList();
        }
        public List<Interviewee> GetSignedUp()
        {
            return _repository.Get()
                              .Where(e => e.Outcome.Name.ToLower() == "signed up")
                              .ToList();
        }
        public Interviewee GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Interviewee> GetByName(string name)
        {
            return _repository.GetByName(name);
        }
        public List<Interviewee> GetBySurname(string surname)
        {
            return _repository.GetBySurname(surname);
        }
        public List<Interviewee> GetByNameSurname(string name, string surname)
        {
            return _repository.GetByNameSurname(name, surname);
        }
        public void Update(Interviewee entity)
        {
            _repository.Update(entity);
        }
        public void Delete(Interviewee entity)
        {
            _repository.Delete(entity);
        }
    }
}
