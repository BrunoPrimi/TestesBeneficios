using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Convercores;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Interfaces;

namespace TestesBeneficios.Domain.Servicos.Implementacoes
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }
   

        public async Task<int> Edit(Guid id ,ProdutoDTO produtoDTO)
        {
            var produto = ConversorProduto.Converter(id, produtoDTO);
           
            return await _repositorioProduto.Edit(produto);
        }

        public async Task<ProdutoDTO> BuscarPeloId(Guid id)
        {
            var produto = await _repositorioProduto.BuscarPeloId(id);

            return ConversorProduto.Converter(produto);
        }

        public async Task<List<ProdutoDTO>> BuscarTodos()
        {
            var produtos = await _repositorioProduto.BuscarTodos();

            return ConversorProduto.Converter(produtos);
        }

        public async Task<int> Criar(ProdutoDTO produtoDTO)
        {
            var produto = ConversorProduto.Converter(Guid.NewGuid(), produtoDTO);
          return await _repositorioProduto.Criar(produto);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioProduto.Excluir(id);
        }
    }
}
