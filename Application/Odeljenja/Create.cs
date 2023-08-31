using Application.Core;
using Application.UnitsOfWork;
using Domain;
using FluentValidation;
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
        public class Command : IRequest<Result<Unit>>
        {
            public Odeljenje Odeljenje { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Odeljenje).SetValidator(new OdeljenjaValidator());
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
                _uof.OdeljenjeRepository.CreateOdeljenje(request.Odeljenje);

                var result = await _uof.SaveAsync();

                if (!result) return Result<Unit>.Failure("Failed to create odeljenje");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
