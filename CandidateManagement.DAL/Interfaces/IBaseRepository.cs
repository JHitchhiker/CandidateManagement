using CandidateManagement.Data.Models;
using System.Collections.Generic;

namespace CandidateManagement.DAL
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T GetById(int id);
        IEnumerable<T> Get();
        void Insert(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Update(T entity);
    }
}
