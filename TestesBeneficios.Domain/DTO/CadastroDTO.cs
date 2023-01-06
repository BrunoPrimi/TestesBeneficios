using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.ValidacoesDTO;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace TestesBeneficios.Domain.DTO
{
    public class CadastroDTO

    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string ConfirmacaoSenha{ get; set; }

        public ValidationResult ValidationResult { get; set; }
        public bool EhValido()
        {
            var erros = new ValidacaoCadastroDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }

    }
}
