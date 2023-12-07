using DesafioCertponto.Domain.Entities;
using FluentValidation;

namespace DesafioCertponto.Service.Validators
{
    public class VotacaoValidator : AbstractValidator<Votacao>
    {
        public VotacaoValidator()
        {
            RuleFor(v => v.RestauranteID).NotNull().NotEmpty().WithMessage("Escolha um restaurante para ser votado!");
            RuleFor(v => v.ProfissionalID).NotNull().NotEmpty().WithMessage("Escolha um funcionário para votar!");
        }
    }
}
