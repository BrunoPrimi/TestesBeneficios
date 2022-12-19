using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class ProdutoFaixaEtaria
    {
       
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int FaixaDe { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int FaixaAte { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public float Preco { get; set; }
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
