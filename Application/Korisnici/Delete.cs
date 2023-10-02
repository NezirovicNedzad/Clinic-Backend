using Application.Core;
using Application.UnitsOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Korisnici
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _uof.KorisniciRepository.GetUser(request.Id);

                if (user == null) return null;

await                _uof.KorisniciRepository.AdminDeleteUser(request.Id);


                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to delete user");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
