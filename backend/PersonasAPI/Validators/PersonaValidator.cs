using FluentValidation;
using PersonasAPI.DTOs;

namespace PersonasAPI.Validators
{
    public class CreatePersonaValidator : AbstractValidator<CreatePersonaDto>
    {
        public CreatePersonaValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(100).WithMessage("El apellido no puede exceder 100 caracteres");

            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio")
                .EmailAddress().WithMessage("El correo debe ser válido");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("El documento es obligatorio")
                .MaximumLength(20).WithMessage("El documento no puede exceder 20 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(15).WithMessage("El teléfono no puede exceder 15 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Telefono));
        }
    }

    public class UpdatePersonaValidator : AbstractValidator<UpdatePersonaDto>
    {
        public UpdatePersonaValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(100).WithMessage("El apellido no puede exceder 100 caracteres");

            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio")
                .EmailAddress().WithMessage("El correo debe ser válido");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("El documento es obligatorio")
                .MaximumLength(20).WithMessage("El documento no puede exceder 20 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(15).WithMessage("El teléfono no puede exceder 15 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Telefono));
        }
    }
}