using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Convercores;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Interfaces;

namespace TestesBeneficios.Domain.Servicos.Implementacoes
{
    public class ServicoProdutoFaixaEtaria : IServicoProdutoFaixaEtaria
    {
        private readonly IRepositorioProdutoFaixaEtaria _repositorioProdutoFaixaEtaria;

        public ServicoProdutoFaixaEtaria(IRepositorioProdutoFaixaEtaria repositorioProdutoFaixaEtaria)
        {
            _repositorioProdutoFaixaEtaria = repositorioProdutoFaixaEtaria;
        }
   
        
        public async Task<int> Edit(Guid id , ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO)
        {
            var produtoFaixaEtaria = ConversorProdutoFaixaEtaria.Converter(id, produtoFaixaEtariaDTO);
           
            return await _repositorioProdutoFaixaEtaria.Edit(produtoFaixaEtaria);
        }

        public async Task<ProdutoFaixaEtariaDTO> BuscarPeloId(Guid id)
        {
            var produtoFaixaEtaria = await _repositorioProdutoFaixaEtaria.BuscarPeloId(id);

            return ConversorProdutoFaixaEtaria.Converter(produtoFaixaEtaria);
        }

        public async Task<List<ProdutoFaixaEtariaDTO>> BuscarTodos()
        {
            var produtoFaixaEtaria = await _repositorioProdutoFaixaEtaria.BuscarTodos();

            return ConversorProdutoFaixaEtaria.Converter(produtoFaixaEtaria);
        }

        public async Task<int> Criar(ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO)
        {
            var produtoFaixaEtaria = ConversorProdutoFaixaEtaria.Converter(Guid.NewGuid(), produtoFaixaEtariaDTO);
          return await _repositorioProdutoFaixaEtaria.Criar(produtoFaixaEtaria);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioProdutoFaixaEtaria.Excluir(id);
        }
    }
}
