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
    public class ListIzabraniLekar
    {
                public class Query : IRequest<Result<List<PacijentDto2>>>
        {
public AppUser lekar {get;set;}


        }



        public class Handler : IRequestHandler<Query, Result<List<PacijentDto2>>>
        {

            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<PacijentDto2>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return   Result<List<PacijentDto2>>.Success(await _uof.PacijentRepository.GetPacijentiLekara(request.lekar));
            }
        }
    }
}