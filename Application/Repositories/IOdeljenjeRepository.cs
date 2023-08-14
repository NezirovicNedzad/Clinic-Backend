using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IOdeljenjeRepository 
    {
        Task<List<Odeljenje>> GetOdeljenja();
        Task<Odeljenje> GetOdeljenje(Guid id);

        void CreateOdeljenje(Odeljenje odeljenje);
        void EditOdeljenje(Guid id,Odeljenje Odeljenje);

        void DeleteOdeljenje(Guid id);
    }
}
