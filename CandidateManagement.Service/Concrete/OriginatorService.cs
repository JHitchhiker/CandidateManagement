using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class OriginatorService : IOriginatorService
    {
        IOriginatorRepository repository;

        public OriginatorService(IOriginatorRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Originator> GetAll()
        {
            return repository.Get();
        }

        public Originator GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Originator entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Originator entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
