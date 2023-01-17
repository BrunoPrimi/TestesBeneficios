
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.ValidacoesDTO;

namespace TestesBeneficios.Domain.DTO
{
    public class SimulacaoDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        public string Cpf { get; set; }
        public enum Abrangencia { }

        public Guid IdProfissao { get; set; }
        public Profissao Profissao { get; set; }

        public Guid IdEntidadeDeClasse { get; set; }
        public EntidadeDeClasse EntidadeDeClasse { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public bool EhValido()
        {
            var erros = new ValidacaoSimulacaoDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
