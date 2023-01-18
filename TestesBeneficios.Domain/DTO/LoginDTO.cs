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
    public class LoginDTO
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            var erros = new ValidacaoLoginDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
