using Domain;
using FluentValidation;

namespace Application.Odeljenja
{
    public class OdeljenjaValidator : AbstractValidator<Odeljenje>
    {
        public OdeljenjaValidator()
        {
            RuleFor(x => x.Naziv).NotEmpty();
            RuleFor(x => x.BrojKreveta).NotEmpty();
            RuleFor(x => x.BrojPacijenata).NotEmpty();
        }
    }
}
