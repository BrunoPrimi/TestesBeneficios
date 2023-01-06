using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public class ProdutoFaixaEtariaDTO
    {
        public Guid Id { get; set; }

        [Display(Name = "Faixa De")]
        public int FaixaDe { get; set; }

        [Display(Name = "Faixa Até")]
        public int FaixaAte { get; set; }

        [Display(Name = "Preço")]
        public float Preco { get; set; }

        public Guid IdProduto { get; set; }

        public ProdutoDTO Produto { get; set; }

       public ValidationResult ValidationResult { get; set;}
        public bool EhValido()
        {
            var erros = new ValidacaoProdutoFaixaEtariaDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
    
