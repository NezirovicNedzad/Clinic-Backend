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
    public class List
    {
        

        public class Query : IRequest<Result<List<Pacijent>>>
        {



        }



        public class Handler : IRequestHandler<Query, Result<List<Pacijent>>>
        {



            private readonly IUnitOfWork _uof;

                   public Handler(IUnitOfWork unitOfWork)
                   {
                             _uof=unitOfWork;

                   }

            public async Task<Result<List<Pacijent>>> Handle(Query request, CancellationToken cancellationToken)
            {
                             return   Result<List<Pacijent>>.Success(await _uof.PacijentRepository.GetPacijents());
            }
        }
    }
}