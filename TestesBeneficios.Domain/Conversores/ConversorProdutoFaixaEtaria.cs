using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorProdutoFaixaEtaria
    {
        public static ProdutoFaixaEtaria Converter(Guid id, ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO)
        {
            return new ProdutoFaixaEtaria
            {
                Id = id,
                FaixaDe = produtoFaixaEtariaDTO.FaixaDe,
                FaixaAte = produtoFaixaEtariaDTO.FaixaAte,
                Preco = produtoFaixaEtariaDTO.Preco,
                IdProduto = produtoFaixaEtariaDTO.IdProduto
            };
        }

        public static ProdutoFaixaEtariaDTO Converter(ProdutoFaixaEtaria produtoFaixaEtaria)
        {
            return new ProdutoFaixaEtariaDTO
            {
                Id = produtoFaixaEtaria.Id,
                FaixaDe = produtoFaixaEtaria.FaixaDe,
                FaixaAte = produtoFaixaEtaria.FaixaAte,
                Preco = produtoFaixaEtaria.Preco,
                IdProduto = produtoFaixaEtaria.IdProduto,
                Produto = ConversorProduto.Converter(produtoFaixaEtaria.Produto)
            };
        }

       public static List<ProdutoFaixaEtariaDTO> Converter(List<ProdutoFaixaEtaria> faixaEtaria)
        {
            return faixaEtaria.Select(x => Converter(x)).ToList();

        }
    }
}
