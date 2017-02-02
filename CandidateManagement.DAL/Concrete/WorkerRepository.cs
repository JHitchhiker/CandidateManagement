using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(CMContext dataContext)
            : base(dataContext)
        {
        }
        public List<Worker> GetByName(string name)
        {
            return context.Workers
                          .Where(e => e.Interviewee.FirstName == name)
                          .ToList();
        }
        public List<Worker> GetBySurname(string surname)
        {
            return context.Workers
                          .Where(e => e.Interviewee.Surname == surname)
                          .ToList();
        }
        public List<Worker> GetByNameSurname(string name, string surname)
        {
            return context.Workers
                          .Where(e => e.Interviewee.Surname == surname
                                   && e.Interviewee.FirstName == name)
                          .ToList();
        }

    }
}
