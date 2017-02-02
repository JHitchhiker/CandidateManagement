using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class OriginService : IOriginService
    {
        IOriginRepository repository;

        public OriginService(IOriginRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Origin> GetAll()
        {
            return repository.Get();
        }

        public Origin GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Origin entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Origin entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
