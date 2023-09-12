using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.UnitsOfWork;
using Domain;
using MediatR;

namespace Application.Pacijenti
{
    public class DetailsPacijent
    {
          public class Query :IRequest<Result<Pacijent>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Pacijent>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

         

            async Task<Result<Pacijent>> IRequestHandler<Query, Result<Pacijent>>.Handle(Query request, CancellationToken cancellationToken)
            {
                var pacijent = await _uof.PacijentRepository.GetPacijent(request.Id);

                return Result<Pacijent>.Success(pacijent);
            }
        }


    }
}