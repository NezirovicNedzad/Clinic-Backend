using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Kartoni
{
    public class KartonValidator:AbstractValidator<Karton>
    {
                 public KartonValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Lekar).NotEmpty();
           
        }
    }
}