using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        Task CreateOdeljenje(Odeljenje odeljenje);
        
        Task EditOdeljenje(Guid id,Odeljenje Odeljenje);

         Task DeleteOdeljenjeAsync(Guid id);
    }
}
