using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.ValidacoesDTO
{
    public class ValidacaoProdutoFaixaEtariaDTO : AbstractValidator<ProdutoFaixaEtariaDTO>
    {
        public ValidacaoProdutoFaixaEtariaDTO() {

            RuleFor(x => x.FaixaDe)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");


            RuleFor(x => x.FaixaAte)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");


            RuleFor(x => x.Preco)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");
              
        }
    }
}
