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

        IPacijentRepository PacijentRepository{get;}
        Task<bool> SaveAsync();
    }
}
