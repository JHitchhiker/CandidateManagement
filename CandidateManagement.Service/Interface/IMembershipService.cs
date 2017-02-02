using CandidateManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Service
{
public interface IMembershipService
    {

        IEnumerable<Membership> GetAll();
        Membership GetById(Int32 id);

        void Create(Membership entity);
        void Update(Membership entity);
        void Delete(Int32 id);
    }
}
