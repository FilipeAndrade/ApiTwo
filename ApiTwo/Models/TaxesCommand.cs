using FluentValidation;
using FluentValidation.Results;

namespace ApiTwo.Models
{
    /// <summary>
    /// Representa o comando necessario para calcular os juros
    /// </summary>
    public class TaxesCommand
    {
        public double ValorInicial { get; set; }

        public int Tempo { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<TaxesCommand>
        {
            public Validator()
            {
                RuleFor(c => c.ValorInicial).GreaterThan(0);
                RuleFor(c => c.Tempo).GreaterThan(0);
            }
        }
    }
}
