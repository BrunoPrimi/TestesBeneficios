
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Enumeradores;

namespace TestesBeneficios.Domain.Entidades
{
    public class Produto
    {
       
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        public DateTime DataCriacao { get; set; }
        public Guid IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public virtual List<ProdutoFaixaEtaria> FaixaEtaria { get; set; }
        public virtual List<ProdutoAbrangencia> Abrangencias { get; set; }

        public AbrangenciaProduto Abrangencia { get; set; }

        [NotMapped]
        public string NomeCodigo
        {
            get
            {
                return $"{Nome} - {Codigo}";
            }
        }

        
       
    }
}
