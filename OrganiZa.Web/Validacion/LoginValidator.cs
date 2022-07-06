using FluentValidation;
using OrganiZa.Web.Models;

namespace OrganiZa.Web.Validacion
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Usuario)
                .NotNull().WithMessage("Este campo no puede estar vacio")
                .NotEmpty().WithMessage("Este campo no puede ser vacio");
            RuleFor(login => login.Contraseña)
                .NotNull().WithMessage("Este campo no puede ser vacio")
                .NotEmpty().WithMessage("Este campo no puede estar vacio")
                .Length(2, 15);
            RuleFor(login => login.status).Equal(false).WithMessage("Correo o contraseña no validos");
        }
    }
}
