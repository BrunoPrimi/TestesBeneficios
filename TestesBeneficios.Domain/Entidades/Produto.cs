using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class Produto
    {
       
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public virtual List<ProdutoFaixaEtaria> FaixaEtaria { get; set; }
        public virtual List<ProdutoAbrangencia> Abrangencia { get; set; }

       
    }
}
