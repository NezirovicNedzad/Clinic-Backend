using Application.Core;
using Application.Dto;
using Application.UnitsOfWork;
using MediatR;

namespace Application.Napomene
{
    public class ListNapomene
    {
        public class Query : IRequest<Result<List<NapomenaDto>>>
        {
            public Guid IdK { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<NapomenaDto>>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<NapomenaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<NapomenaDto>>.Success(await _uof.NapomenaRepository.GetNapomene(request.IdK));
            }
        }
    }
}
