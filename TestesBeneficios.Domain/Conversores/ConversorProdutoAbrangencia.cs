using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorProdutoAbrangencia
    {
        public static ProdutoAbrangencia Converter(Guid id, ProdutoAbrangenciaDTO produtoAbrangenciaDTO)
        {
            return new ProdutoAbrangencia
            {
                Id = id,
                Cidade = produtoAbrangenciaDTO.Cidade,
                UF = produtoAbrangenciaDTO.Cidade,
                IdProduto = produtoAbrangenciaDTO.IdProduto
            };
        }

        public static ProdutoAbrangenciaDTO Converter(ProdutoAbrangencia produtoAbrangencia)
        {
            return new ProdutoAbrangenciaDTO
            {
                Id = produtoAbrangencia.Id,
                Cidade = produtoAbrangencia.Cidade,
                UF = produtoAbrangencia.UF,
                IdProduto = produtoAbrangencia.IdProduto,
                Produto = ConversorProduto.Converter(produtoAbrangencia.Produto)
            };
        }

       public static List<ProdutoAbrangenciaDTO> Converter(List<ProdutoAbrangencia> abrangencia)
        {
            return abrangencia.Select(x => Converter(x)).ToList();

        }
    }
}
