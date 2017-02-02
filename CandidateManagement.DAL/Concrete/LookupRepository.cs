using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class LookupRepository<T> : ILookupRepository<T> where T : LookupBaseModel
    {
        CMContext context;

        public LookupRepository(CMContext context)
        {
            this.context = context;
        }

        public T GetById(Int32 id)
        {
            return context.Set<T>().Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            entity.Active = true;
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.Active = false;
            context.SaveChanges();
        }
    }
}