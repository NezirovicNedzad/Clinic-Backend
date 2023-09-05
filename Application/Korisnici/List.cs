using Application.Core;
using Application.UnitsOfWork;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Korisnici
{
    public class List
    {
        public class Query : IRequest<Result<List<AppUser>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<AppUser>>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<AppUser>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<AppUser>>.Success(await _uof.KorisniciRepository.GetUsers());
            }
        }
    }
}
