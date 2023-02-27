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
    public class PagamentoDTO
    {
        public Guid Id { get; set; }

        public string ChavePix { get; set; }

        public string Banco { get; set; }

        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Digito { get; set; }
        public string TipoDeConta { get; set; }

        public int Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public string CodSeguranca { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            var erros = new ValidacaoPagamentoDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
