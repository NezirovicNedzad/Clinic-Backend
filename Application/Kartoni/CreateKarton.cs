using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.UnitsOfWork;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Kartoni
{
    public class CreateKarton
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Karton Karton { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Karton).SetValidator(new KartonValidator());
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
            await _uof.KartonRepository.CreateKarton(request.Karton);

                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to create odeljenje");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}