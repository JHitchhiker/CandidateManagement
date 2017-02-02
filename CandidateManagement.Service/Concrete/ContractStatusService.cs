using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class ContractStatusService : IContractStatusService
    {
        IContractStatusRepository repository;

        public ContractStatusService(IContractStatusRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ContractStatus> GetAll()
        {
            return repository.Get();
        }

        public ContractStatus GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(ContractStatus entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(ContractStatus entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
