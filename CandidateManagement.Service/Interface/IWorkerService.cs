using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface IWorkerService
    {
        List<Worker> Get();
        Worker GetById(int id);
        List<Worker> GetCurrent();
        List<Worker> GetFinishingSoon();
        List<Worker> GetOutOfContract();
        void Create(Worker entity);
        void Update(Worker entity);
        void Delete(int id);
        void Delete(Worker entity);
        
    }
}
