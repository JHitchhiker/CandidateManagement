using CandidateManagement.Data.Context;
using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.DAL
{
    public class LeaverRepository : BaseRepository<Leaver>, ILeaverRepository
    {
        public LeaverRepository(CMContext dataContext)
            : base(dataContext)
        {
        }
        public List<Leaver> GetByName(string name)
        {
            return context.Leavers
                          .Where(e => e.Interviewee.FirstName == name)
                          .ToList();
        }
        public List<Leaver> GetBySurname(string surname)
        {
            return context.Leavers
                          .Where(e => e.Interviewee.Surname == surname)
                          .ToList();
        }
        public List<Leaver> GetByNameSurname(string name, string surname)
        {
            return context.Leavers
                          .Where(e => e.Interviewee.Surname == surname
                                   && e.Interviewee.FirstName == name)
                          .ToList();
        }
    }
}
