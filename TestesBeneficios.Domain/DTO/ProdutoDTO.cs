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
    public class ProdutoDTO
    {

        public Guid Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        public DateTime DataCriacao { get; set; }
       
        public Guid IdEmpresa { get; set; }
        
        public EmpresaDTO Empresa { get; set; }
        
        public virtual List<ProdutoFaixaEtaria> FaixaEtaria { get; set; }
        
        public virtual List<ProdutoAbrangencia> Abrangencias { get; set; }

        public AbrangenciaProduto Abrangencia { get; set; }

        public ValidationResult ValidationResult { get; set; }

        [NotMapped]
        public string NomeCodigo
        {
            get
            {
                return $"{Nome} - {Codigo}";
            }
        }

        public bool EhValido()
        {
            var erros = new ValidacaoProdutoDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
    
