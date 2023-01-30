using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.ValidacoesDTO
{
    public class ValidacaoSimulacaoDTO : AbstractValidator<SimulacaoDTO>
    {
        public ValidacaoSimulacaoDTO() {

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
                .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Email)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Cpf)
             .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
             .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
             .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

        }

        
    }
    public class ValidacaoSimulacao_DistribuicaoDTO : AbstractValidator<SimulacaoDTO>
    {
        public ValidacaoSimulacao_DistribuicaoDTO()
        {

            RuleFor(x => x.SimulacaoDistribuicaoVida)
                .Must(x => x.Any(y => y.Quantidade > 0)).WithMessage("Informe pelo menos a faixa etária de uma vida!");

        }


    }
}
