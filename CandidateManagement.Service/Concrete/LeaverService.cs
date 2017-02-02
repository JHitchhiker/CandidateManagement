using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public class LeaverService : ILeaverService
    {
        ILeaverRepository _repository;

        public LeaverService(ILeaverRepository repository)
        {
            _repository = repository;
        }
        public void Create(Leaver entity)
        {
            _repository.Insert(entity);
        }
        public List<Leaver> Get()
        {
            return _repository.Get().ToList();
        }
        public List<Leaver> GetByName(string name)
        {
            return _repository.GetByName(name);
        }
        public List<Leaver> GetBySurname(string surname)
        {
            return _repository.GetBySurname(surname);
        }
        public List<Leaver> GetByNameSurname(string name, string surname)
        {
            return _repository.GetByNameSurname(name, surname);
        }
        public void Update(Leaver entity)
        {
            _repository.Update(entity);
        }
        public void Delete(Leaver entity)
        {
            _repository.Delete(entity);
        }
    }
}
