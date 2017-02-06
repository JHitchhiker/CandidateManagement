using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class LeavingReasonService : ILeavingReasonService
    {
        ILeavingReasonRepository repository;

        public LeavingReasonService(ILeavingReasonRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<LeavingReason> GetAll()
        {
            return repository.Get();
        }

        public LeavingReason GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(LeavingReason entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(LeavingReason entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
