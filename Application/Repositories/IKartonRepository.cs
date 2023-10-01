using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Repositories
{
    public interface IKartonRepository
    {
       Task<KartonDto> GetKartonPacijenta(Guid idP,Guid id);
       Task<List<KartonDtoIstorija>> GetKartoniPacijenta(Guid IdPacijenta);
Task CreateKarton(Karton karton);
    }
}