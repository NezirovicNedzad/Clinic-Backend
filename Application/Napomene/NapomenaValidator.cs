using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Napomene
{
    public class NapomenaValidator : AbstractValidator<Napomena>
    {
        public NapomenaValidator()
        {
            RuleFor(x => x.Primedba).NotEmpty();
            RuleFor(x => x.NezeljenoDejstvo).NotEmpty();
        }
    }
}
