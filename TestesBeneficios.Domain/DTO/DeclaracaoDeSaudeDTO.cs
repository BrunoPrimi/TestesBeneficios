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
using TestesBeneficios.Domain.Enumeradores;
using TestesBeneficios.Domain.ValidacoesDTO;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace TestesBeneficios.Domain.DTO
{
    public class DeclaracaoDeSaudeDTO
    {
        public Guid Id { get; set; }

        public Resposta Resposta { get; set; }


        public string Detalhes { get; set; }

        public DateTime DataDoEvento { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            var erros = new ValidacaoDeclaracaoDeSaudeDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
