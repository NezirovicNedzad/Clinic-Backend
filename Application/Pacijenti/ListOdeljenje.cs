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
    public class ListOdeljenje
    {

                public class Query : IRequest<Result<List<Pacijent>>>
        {


public Odeljenje Odeljenje;


        }


        public class Handler : IRequestHandler<Query, Result<List<Pacijent>>>
        {

            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<Pacijent>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
 return   Result<List<Pacijent>>.Success(await _uof.PacijentRepository.GetPacijentiPoOdeljenju(request.Odeljenje));
            }
        }
    }
}