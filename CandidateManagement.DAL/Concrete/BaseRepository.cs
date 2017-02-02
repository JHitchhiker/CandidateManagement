using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandidateManagement.DAL
{
    public class BaseRepository<T>: IBaseRepository<T> where T :BaseModel
    {
        protected CMContext context;

        public BaseRepository(CMContext context)
        {
            this.context = context;
        }

        public T GetById(Int32 id)
        {
            
            return context.Set<T>()
                          .Where(e => e.Id == id)
                          .FirstOrDefault();
        }

        public IEnumerable<T> Get()
        {
            return context.Set<T>()
                          .Where(e => e.Active)
                          .ToList();
        }

        public IEnumerable<T> GetPaged(int page, int pageSize)
        {
            return context.Set<T>().Skip(pageSize * (page - 1)).Take(pageSize);
        }

        public void Insert(T entity)
        {
            entity.DateChanged = DateTime.Now;
            entity.DateCreated = DateTime.Now;
            entity.Active = true;

            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            entity.DateChanged = DateTime.Today;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Delete(T entity)
        {
            entity.Active = false;
            context.SaveChanges();
        }
    }
}
