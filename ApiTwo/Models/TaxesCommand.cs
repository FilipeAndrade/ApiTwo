using FluentValidation;
using FluentValidation.Results;

namespace ApiTwo.Models
{
    /// <summary>
    /// Representa o comando necessario para calcular os juros
    /// </summary>
    public class TaxesCommand
    {
        /// <summary>
        /// Valor inicial para o calculo do imposto
        /// </summary>
        public double ValorInicial { get; set; }

        /// <summary>
        /// Tempo em meses para calculo do imposto
        /// </summary>
        public int Tempo { get; set; }

        /// <summary>
        /// Verifica se o command e valido
        /// </summary>
        /// <returns>Retorna sucesso ou uma lista de erros</returns>
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
