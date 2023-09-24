using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Dto;
using Application.UnitsOfWork;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Pregledi
{
    public class CreatePregled
    {
             public class Command : IRequest<Result<Unit>>
        {
            public Pregled Pregled { get; set; }
        }

 public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Pregled).SetValidator(new PregledValidator());
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

               _uof.PregledRepository.CreatePregled(request.Pregled);

             
                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to create pregled");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}