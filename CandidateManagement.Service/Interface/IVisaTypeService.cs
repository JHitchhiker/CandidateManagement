using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface IVisaTypeService
    {
        IEnumerable<VisaType> GetAll();
        VisaType GetById(Int32 id);
        void Create(VisaType entity);
        void Update(VisaType entity);
        void Delete(Int32 id);
    }
}
