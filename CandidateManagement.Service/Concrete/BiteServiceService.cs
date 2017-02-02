using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public class BiteServiceService : IBiteServiceService
    {
        IBiteServiceRepository repository;

        public BiteServiceService(IBiteServiceRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BiteService> GetAll()
        {
            return repository.Get();
        }

        public BiteService GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(BiteService entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(BiteService entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
