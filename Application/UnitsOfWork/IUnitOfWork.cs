using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitsOfWork
{
   public interface IUnitOfWork
    {
        IOdeljenjeRepository OdeljenjeRepository { get; }
        IKorisniciRepository KorisniciRepository { get; }
IKartonRepository KartonRepository{get;}
        IPacijentRepository PacijentRepository{get;}
        IPregledRepository PregledRepository {get;}
        Task<bool> SaveAsync();
    }
}
