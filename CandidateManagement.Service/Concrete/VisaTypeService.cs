using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class VisaTypeService : IVisaTypeService
    {
        IVisaTypeRepository repository;

        public VisaTypeService(IVisaTypeRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<VisaType> GetAll()
        {
            return repository.Get();
        }

        public VisaType GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(VisaType entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(VisaType entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
