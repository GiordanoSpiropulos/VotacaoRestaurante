using DesafioCertponto.Domain.Entities;
using FluentValidation;

namespace DesafioCertponto.Service.Validators
{
    public class ProfissionalValidator : AbstractValidator<Profissional>
    {
        public ProfissionalValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, insira o nome do funcionário.")
                .NotNull().WithMessage("Por favor, insira o nome do funcionário.");
        }
    }
}
