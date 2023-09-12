using Application.Repositories;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        
         private readonly UserManager<AppUser> _userManager;
        public UnitOfWork(DataContext dataContext, IMapper mapper, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IOdeljenjeRepository OdeljenjeRepository => new OdeljenjeRepository(_dataContext,_mapper,_userManager);

        public IKorisniciRepository KorisniciRepository => new KorisniciRepository(_dataContext);

        public IPacijentRepository PacijentRepository => new PacijentRepository(_dataContext,_userManager);

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
