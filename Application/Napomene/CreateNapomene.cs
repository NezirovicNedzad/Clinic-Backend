using Application.Core;
using Application.UnitsOfWork;
using Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Napomene
{
    public class CreateNapomene
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Napomena Napomena { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Napomena).SetValidator(new NapomenaValidator());
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
                _uof.NapomenaRepository.CreateNapomena(request.Napomena);

                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to create napomenu");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
