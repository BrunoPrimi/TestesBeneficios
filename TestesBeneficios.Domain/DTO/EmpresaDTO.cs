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
    public class EmpresaDTO
    {
        public Guid Id { get; set; }

        public string Cnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }


        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        public DateTime DataCriacao { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EhValido()
        {
            var erros = new ValidacaoEmpresaDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
