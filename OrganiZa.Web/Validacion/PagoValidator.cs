using FluentValidation;
using FluentValidation.AspNetCore;
using OrganiZa.Web.Models;


namespace OrganiZa.Web.Validacion
{
    public class PagoValidator : AbstractValidator<PagoModels>
    {
        public PagoValidator()
        {
            RuleFor(Pago => Pago.pagos.Mespagado)
                .NotNull().WithMessage("Este campo no puede estar vacio")
                .NotEmpty().WithMessage("Este campo no puede ser vacio");
            RuleFor(Pago => Pago.file)
               .NotNull().WithMessage("Este campo no puede ser vacio")
               .NotEmpty().WithMessage("Este campo no puede estar vacio");
            RuleFor(Pago => Pago.pagos.Fichapago)
              .NotNull().WithMessage("Su ficha de pago no esta activa o no se  completo los datos")
              .NotEmpty().WithMessage("Su ficha de pago no esta activa o no se  completo los datos");
        }
    }
}
