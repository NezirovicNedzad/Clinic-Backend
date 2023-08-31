using Application.Core;
using Application.UnitsOfWork;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Odeljenja
{
    public class List
    {

        public class Query : IRequest<Result<List<Odeljenje>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Odeljenje>>>
        {
            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<List<Odeljenje>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Odeljenje>>.Success(await _uof.OdeljenjeRepository.GetOdeljenja());
            }
        }
    }
}
