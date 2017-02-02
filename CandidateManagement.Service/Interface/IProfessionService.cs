using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IProfessionService
    {

        IEnumerable<Profession> GetAll();
        Profession GetById(Int32 id);

        void Create(Profession entity);
        void Update(Profession entity);
        void Delete(Int32 id);
    }
}
