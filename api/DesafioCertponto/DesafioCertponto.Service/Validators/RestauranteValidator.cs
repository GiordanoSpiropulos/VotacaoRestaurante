using DesafioCertponto.Domain.Entities;
using FluentValidation;

namespace DesafioCertponto.Service.Validators
{
    public class RestauranteValidator : AbstractValidator<Restaurante>
    {
        public RestauranteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, insira o nome do restaurante.")
                .NotNull().WithMessage("Por favor, insira o nome do restaurante.");
        }
    }
}
