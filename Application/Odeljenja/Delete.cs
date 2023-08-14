using Application.UnitsOfWork;
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
    public class Delete
    {



        public class Command : IRequest
        {
         public   Guid Id { get; set; }
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


                _uof.OdeljenjeRepository.DeleteOdeljenje(request.Id);

                await _uof.SaveAsync();


                return Unit.Value;


               
            }
        }
    }
}
