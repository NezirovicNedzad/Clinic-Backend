using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.UnitsOfWork;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Kartoni
{
    public class ListKartoni
    {
        public class Query : IRequest<Result<KartonDto>>
        {

            public Guid IdO{get; set;}
            public Guid IdP{get; set;}
        }

        public class Handler : IRequestHandler<Query, Result<KartonDto>>
        {

            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<KartonDto>> Handle(Query request, CancellationToken cancellationToken)
            {
               return Result<KartonDto>.Success(await _uof.KartonRepository.GetKartoniPacijenta(request.IdP,request.IdO));
            }
        }
    }
    
}