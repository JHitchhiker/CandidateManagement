using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class OutcomeService : IOutcomeService
    {
        IOutcomeRepository repository;

        public OutcomeService(IOutcomeRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Outcome> GetAll()
        {
            return repository.Get();
        }

        public Outcome GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Outcome entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Outcome entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
