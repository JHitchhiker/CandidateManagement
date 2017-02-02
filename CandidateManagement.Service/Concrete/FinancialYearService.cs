using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public class FinancialYearService : IFinancialYearService
    {
        IFinancialYearRepository _repository;

        public FinancialYearService(IFinancialYearRepository repository)
        {
            _repository = repository;
        }
        public void Create(FinancialYear entity)
        {
            _repository.Insert(entity);
        }
        public List<FinancialYear> Get()
        {
            return _repository.Get().ToList();
        }
        public FinancialYear GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(FinancialYear entity)
        {
            _repository.Update(entity);
        }
        public void Delete(FinancialYear entity)
        {
            _repository.Delete(entity);
        }
    }
}
