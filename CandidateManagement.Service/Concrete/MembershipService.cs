using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public class MembershipService : IMembershipService
    {
        IMembershipRepository repository;

        public MembershipService(IMembershipRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Membership> GetAll()
        {
            return repository.Get();
        }

        public Membership GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Membership entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Membership entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
