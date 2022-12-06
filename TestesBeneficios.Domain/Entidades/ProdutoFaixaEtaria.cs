using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class ProdutoFaixaEtaria
    {
       
        public Guid Id { get; set; }
        public int FaixaDe { get; set; }
        public int FaixaAte { get; set; }
        public float Preco { get; set; }
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
