using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
    public interface ILeaverService
    {
        void Create(Leaver entity);
        List<Leaver> Get();
        List<Leaver> GetByName(string name);
        List<Leaver> GetBySurname(string surname);
        List<Leaver> GetByNameSurname(string name, string surname);
        void Update(Leaver entity);
        void Delete(Leaver entity);
    }
}
