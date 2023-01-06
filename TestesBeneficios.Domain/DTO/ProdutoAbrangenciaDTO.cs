using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Enumeradores;
using TestesBeneficios.Domain.ValidacoesDTO;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.ComponentModel.DataAnnotations;

namespace TestesBeneficios.Domain.DTO
{
    public class ProdutoAbrangenciaDTO
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string UF { get; set; }
        public Guid IdProduto { get; set; }
        public ProdutoDTO Produto { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool EhValido()
        {
            var erros = new ValidacaoProdutoAbrangenciaDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
    
