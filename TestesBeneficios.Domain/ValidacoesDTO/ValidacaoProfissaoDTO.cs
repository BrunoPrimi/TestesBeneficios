using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.ValidacoesDTO
{
    public class ValidacaoProfissaoDTO : AbstractValidator<ProfissaoDTO>
    {
        public ValidacaoProfissaoDTO()
        {

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
                .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

        }
    }
}
