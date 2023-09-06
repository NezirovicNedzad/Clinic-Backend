using Domain;
using FluentValidation;

namespace Application.Korisnici
{
    public class KorisniciValidator : AbstractValidator<AppUser>
    {
        public KorisniciValidator()
        {
            RuleFor(x => x.Ime).NotEmpty();
            RuleFor(x => x.Prezime).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
        }
    }
}
