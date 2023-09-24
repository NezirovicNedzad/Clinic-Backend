using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.UnitsOfWork;
using MediatR;

namespace Application.Pacijenti
{
    public class DeletePacijent
    {
                public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }



        public class Handle : IRequestHandler<Command, Result<Unit>>
        {


            private readonly IUnitOfWork _uof;

            public Handle(IUnitOfWork uof)
            {
                _uof = uof;
            }

            async Task<Result<Unit>> IRequestHandler<Command, Result<Unit>>.Handle(Command request, CancellationToken cancellationToken)
            {
             
   var pacijent = await _uof.PacijentRepository.GetPacijent(request.Id);

                if (pacijent == null) return null;

            await     _uof.PacijentRepository.DeletePacijentAsync(request.Id);
            
                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to delete pacijent");

                return Result<Unit>.Success(Unit.Value);
            
            }
            
        }


    }
}