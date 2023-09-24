using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;
using FluentValidation;

namespace Application.Pregledi
{
    public class PregledValidator:AbstractValidator<Pregled>
    {
                 public PregledValidator()
        {
            RuleFor(x => x.Anamneza).NotEmpty();
            RuleFor(x => x.Dijagnoza).NotEmpty();
            RuleFor(x => x.Terapija).NotEmpty();
        }
    }
}