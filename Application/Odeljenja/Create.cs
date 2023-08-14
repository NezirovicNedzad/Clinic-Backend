using Application.UnitsOfWork;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Odeljenja
{
    public class Create
    {


        public class Command : IRequest
        {
            public Odeljenje Odeljenje { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {

            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {


                _uof.OdeljenjeRepository.CreateOdeljenje(request.Odeljenje);

                await _uof.SaveAsync();


                return Unit.Value;
                
            }
        }
    }
}
