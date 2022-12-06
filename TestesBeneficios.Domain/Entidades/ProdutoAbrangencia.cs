using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class ProdutoAbrangencia
    {
       
        public Guid Id { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
