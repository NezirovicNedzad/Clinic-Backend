using Application.Core;
using Application.Dto;
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
        public class Query : IRequest<Result<List<UserGetDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<UserGetDto>>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<UserGetDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<UserGetDto>>.Success(await _uof.KorisniciRepository.GetUsers());
            }
        }
    }
}
