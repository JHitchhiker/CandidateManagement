using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public interface IWorkerRepository : IBaseRepository<Worker>
    {
        List<Worker> GetByName(string name);
        List<Worker> GetBySurname(string surname);
        List<Worker> GetByNameSurname(string name, string surname);
    }
}
