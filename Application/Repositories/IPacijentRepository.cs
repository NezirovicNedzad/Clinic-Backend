using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;

namespace Application.Repositories
{
    public interface IPacijentRepository
    {
        
        Task <List<Pacijent>> GetPacijents(); 

        Task <List<Pacijent>> GetPacijentiPoOdeljenju(Odeljenje odeljenje);
         Task<Pacijent> GetPacijent(Guid id);
         void CreatePacijent(Pacijent pacijent);

         Task DeletePacijentAsync(Guid id);


    }
}