using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface IOriginService
    {

        IEnumerable<Origin> GetAll();
        Origin GetById(Int32 id);

        void Create(Origin entity);
        void Update(Origin entity);
        void Delete(Int32 id);
    }
}
