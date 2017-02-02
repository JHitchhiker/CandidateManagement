using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface IOriginatorService
    {

        IEnumerable<Originator> GetAll();
        Originator GetById(Int32 id);

        void Create(Originator entity);
        void Update(Originator entity);
        void Delete(Int32 id);
    }
}
