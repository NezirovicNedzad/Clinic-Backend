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
       Task<KartonDto> GetKartoniPacijenta(Guid idP,Guid idO);
    }
}