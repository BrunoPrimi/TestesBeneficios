using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorProduto
    {
        public static Produto Converter(Guid id, ProdutoDTO produtoDTO)
        {
            return new Produto
            {
                Id = id,
                Nome = produtoDTO.Nome,
                Codigo = produtoDTO.Codigo,
                DataCriacao = produtoDTO.DataCriacao,
                IdEmpresa = produtoDTO.IdEmpresa
            };
        }

        public static ProdutoDTO Converter(Produto produto)
        {
            if (produto == null)
            {
                return null;
            }
            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Codigo = produto.Codigo,
                DataCriacao = produto.DataCriacao,
                IdEmpresa = produto.IdEmpresa,
                FaixaEtaria = produto.FaixaEtaria

            };
        }

        public static List<ProdutoDTO> Converter(List<Produto> produtos)
        {
            return produtos.Select(x => Converter(x)).ToList();

        }
    }
}
