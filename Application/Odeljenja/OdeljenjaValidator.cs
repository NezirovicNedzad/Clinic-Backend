using Domain;
using FluentValidation;

namespace Application.Odeljenja
{
    public class OdeljenjaValidator : AbstractValidator<Odeljenje>
    {
        public OdeljenjaValidator()
        {
            RuleFor(x => x.Naziv).NotEmpty().WithMessage("Naziv must not be empty");
            RuleFor(x => x.BrojKreveta).Must(brojKreveta => brojKreveta > 0).WithMessage("Broj kreveta must be greater than 0");
            RuleFor(x => x.BrojPacijenata).Must(brojPacijenata => brojPacijenata > 0).WithMessage("Broj pacijenata must be greater than 0");
            RuleFor(x => x.SpecijalizacijaNaziv).NotEmpty().WithMessage("Zvanje must not be empty");

        }
    }
}
