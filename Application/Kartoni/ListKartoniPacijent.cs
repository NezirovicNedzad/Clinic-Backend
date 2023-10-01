using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.UnitsOfWork;
using MediatR;

namespace Application.Kartoni
{
    public class ListKartoniPacijent
    {
                public class Query : IRequest<Result<List<KartonDtoIstorija>>>
        {

          
            public Guid IdPacijent{get; set;}
        }



        public class Handler : IRequestHandler<Query, Result<List<KartonDtoIstorija>>>
        {


            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<KartonDtoIstorija>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<KartonDtoIstorija>>.Success(await _uof.KartonRepository.GetKartoniPacijenta(request.IdPacijent));
            }
        }


    }
}