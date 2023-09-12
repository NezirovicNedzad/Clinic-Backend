using Application.Core;
using Application.UnitsOfWork;
using MediatR;

namespace Application.Odeljenja
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var odeljenje = await _uof.OdeljenjeRepository.GetOdeljenje(request.Id);

                if (odeljenje == null) return null;

            await     _uof.OdeljenjeRepository.DeleteOdeljenjeAsync(request.Id);
            
                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to delete odeljenje");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
