using FluentValidation;
using FluentValidation.AspNetCore;
using OrganiZa.Web.Models;


namespace OrganiZa.Web.Validacion
{
    public class AprobacionValidator : AbstractValidator<AprobacionModels>
    {
        public AprobacionValidator()
        {
            RuleFor(login => login.pagos.Statusdepago)
                .NotNull().WithMessage("Este campo no puede estar vacio seleccione una opcion")
                .NotEmpty().WithMessage("Este campo no puede estar vacio seleccione una opcion");
        
        }
    }
}
