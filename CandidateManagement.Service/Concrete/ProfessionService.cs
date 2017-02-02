using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class ProfessionService : IProfessionService
    {
        IProfessionRepository repository;

        public ProfessionService(IProfessionRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Profession> GetAll()
        {
            return repository.Get();
        }

        public Profession GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Profession entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Profession entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
