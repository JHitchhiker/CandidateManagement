﻿using CandidateManagement.DAL;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public class EthnicityService : IEthnicityService
    {
        IEthnicityRepository repository;

        public EthnicityService(IEthnicityRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Ethnicity> GetAll()
        {
            return repository.Get();
        }

        public Ethnicity GetById(Int32 id)
        {
            return repository.GetById(id);
        }

        public void Create(Ethnicity entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateChanged = DateTime.Now;
            repository.Insert(entity);
        }

        public void Update(Ethnicity entity)
        {
            repository.Update(entity);
        }

        public void Delete(Int32 id)
        {
            repository.Delete(repository.GetById(id));
        }
    }
}
