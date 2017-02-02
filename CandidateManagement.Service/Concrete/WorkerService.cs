using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public class WorkerService : IWorkerService
    {
        IWorkerRepository _repository;
        public WorkerService(IWorkerRepository repository)
        {
            _repository = repository;
        }
        public List<Worker> Get()
        {
            return _repository.Get()
                              .ToList();
        }
        public Worker GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Worker> GetCurrent()
        {
            return _repository.Get()
                              .Where(e => e.ContractEnd >= DateTime.Now
                                       && e.Completed == false)
                              .ToList(); 
        }
        public List<Worker> GetFinishingSoon()
        {
            return _repository.Get()
                              .Where(e => e.ContractEnd.Date.Subtract(DateTime.Today).Days <= 30
                                       && e.ContractEnd.Date.Subtract(DateTime.Today).Days >= 0
                                       && e.Completed == false)
                              .OrderByDescending(o => o.ContractEnd)
                              .ToList();
        }
        public List<Worker> GetOutOfContract()
        {
            return _repository.Get()
                              .Where(e => e.ContractEnd <= DateTime.Today
                                       && e.Completed == false)
                              .ToList();
        }
        public void Create(Worker entity)
        {
            _repository.Insert(entity);
        }
        public void Update(Worker entity)
        {
            _repository.Update(entity);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public void Delete(Worker entity)
        {
            _repository.Delete(entity);
        }
    }
}
