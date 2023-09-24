using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;

namespace Application.Repositories
{
    public interface IPregledRepository
    {
        void CreatePregled(Pregled pregled);

        Task<List<PregledDto2>>GetPregledi(Guid idKartona);

        
    }
}