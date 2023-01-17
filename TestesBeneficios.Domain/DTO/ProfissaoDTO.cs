using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.ValidacoesDTO;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace TestesBeneficios.Domain.DTO
{
    public class ProfissaoDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            var erros = new ValidacaoProfissaoDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
