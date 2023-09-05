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
    public class Details 
    {
        public class Query : IRequest<Result<AppUser>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AppUser>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<AppUser>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _uof.KorisniciRepository.GetUser(request.Id);

                return Result<AppUser>.Success(user);
            }
        }
    }
}
