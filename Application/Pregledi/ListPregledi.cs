using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.UnitsOfWork;
using MediatR;

namespace Application.Pregledi
{
    public class ListPregledi
    {
        public class Query : IRequest<Result<List<PregledDto2>>>
        {
            public Guid IdK{get;set;}
        }
        public class Handler : IRequestHandler<Query, Result<List<PregledDto2>>>
        {

            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<PregledDto2>>> Handle(Query request, CancellationToken cancellationToken)
            {
                    return   Result<List<PregledDto2>>.Success(await _uof.PregledRepository.GetPregledi(request.IdK));
            }
        }
    }
}