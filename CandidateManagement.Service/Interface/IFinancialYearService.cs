using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IFinancialYearService
    {
        void Create(FinancialYear entity);
        List<FinancialYear> Get();
        FinancialYear GetById(int id);
        void Update(FinancialYear entity);
        void Delete(FinancialYear entity);
    }
}
