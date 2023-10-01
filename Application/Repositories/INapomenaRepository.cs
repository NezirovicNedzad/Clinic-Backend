using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface INapomenaRepository
    {
        void CreateNapomena(Napomena napomena);
        Task<List<NapomenaDto>> GetNapomene(Guid idKartona);
    }
}
