using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface ISkillService
    {
        IEnumerable<Skill> GetAll();
        Skill GetById(Int32 id);
        void Create(Skill entity);
        void Update(Skill entity);
        void Delete(Int32 id);
    }
}
