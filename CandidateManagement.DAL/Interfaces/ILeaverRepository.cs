using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public interface ILeaverRepository : IBaseRepository<Leaver>
    {
        List<Leaver> GetByName(string name);
        List<Leaver> GetBySurname(string surname);
        List<Leaver> GetByNameSurname(string name, string surname);
    }
}
