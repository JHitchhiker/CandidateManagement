using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class SkillService : ISkillService
    {
        ISkillRepository repository;

        public SkillService(ISkillRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Skill> GetAll()
        {
            return repository.Get();
        }

        public Skill GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Skill entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Skill entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
