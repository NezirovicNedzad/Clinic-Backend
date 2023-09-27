using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.UnitsOfWork;
using Domain;
using FluentValidation;
using MediatR;
using MediatR.Wrappers;

namespace Application.Pacijenti
{
    public class PrebaciPacijenta
    {
         public class Command : IRequest<Result<Unit>>
        {
          public Guid IdP{get;set;}
          public Pacijent Pacijent {get;set;}
        }

public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Pacijent).SetValidator(new PacijentValidator());
            }
        }



        public class Handler : IRequestHandler<Command, Result<Unit>>
        {

            private readonly IUnitOfWork _uof;

            public Handler(IUnitOfWork uof)
            {
                _uof = uof;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                 var pacijent = await _uof.PacijentRepository.GetPacijent(request.IdP);

                if (pacijent == null) return null;

             await   _uof.PacijentRepository.PrebaciPacijenta(request.IdP, request.Pacijent);
               
                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to update odeljenje");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}