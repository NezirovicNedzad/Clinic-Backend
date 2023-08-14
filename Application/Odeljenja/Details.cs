using Application.UnitsOfWork;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Odeljenja
{
    public class Details :IRequest <Odeljenje>

    {


        public class Query :IRequest<Odeljenje>
        {
            public Guid Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, Odeljenje>
        {


            private readonly IUnitOfWork  _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Odeljenje> Handle(Query request, CancellationToken cancellationToken)
            {

                return await _uof.OdeljenjeRepository.GetOdeljenje(request.Id);
            }
        }
    }
}
