using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public interface ILookupRepository<T> where T : LookupBaseModel
    {
        T GetById(Int32 id);
        IEnumerable<T> Get();

        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
