using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class ProdutoAbrangencia
    {
       
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string UF { get; set; }
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
