using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;
using FluentValidation;

namespace Application.Pacijenti
{
    public class PacijentValidator:AbstractValidator<Pacijent>
    {
         public PacijentValidator()
        {
            RuleFor(x => x.Ime).NotEmpty();
            RuleFor(x => x.Prezime).NotEmpty();
            RuleFor(x => x.JMBG).NotEmpty();
        }
        
        
    }
}