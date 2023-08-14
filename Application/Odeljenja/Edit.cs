using Application.UnitsOfWork;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Odeljenja
{
    public class Edit
    {



        public class Command : IRequest
        {


            public Odeljenje Odeljenje { get; set; }
        }




        public class Handler : IRequestHandler<Command>
        {


            private readonly IUnitOfWork _uof;
            public Handler( IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                _uof.OdeljenjeRepository.EditOdeljenje(request.Odeljenje.Id, request.Odeljenje);
                await _uof.SaveAsync();

                return Unit.Value;

            }
        }
    }
}
