using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.UnitsOfWork;
using Domain;
using MediatR;

namespace Application.Pacijenti
{
    public class DetailsPacijent
    {
          public class Query :IRequest<Result<PacijentDto2>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PacijentDto2>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

         

            async Task<Result<PacijentDto2>> IRequestHandler<Query, Result<PacijentDto2>>.Handle(Query request, CancellationToken cancellationToken)
            {
                var pacijent = await _uof.PacijentRepository.GetPacijent(request.Id);

                return Result<PacijentDto2>.Success(pacijent);
            }
        }


    }
}