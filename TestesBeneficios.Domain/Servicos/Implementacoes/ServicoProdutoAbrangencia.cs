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
    public class ServicoProdutoAbrangencia : IServicoProdutoAbrangencia
    {
        private readonly IRepositorioProdutoAbrangencia _repositorioProdutoAbrangencia;

        public ServicoProdutoAbrangencia(IRepositorioProdutoAbrangencia repositorioProdutoAbrangencia)
        {
            _repositorioProdutoAbrangencia = repositorioProdutoAbrangencia;
        }
   
        
        public async Task<int> Edit(Guid id , ProdutoAbrangenciaDTO produtoAbrangenciaDTO)
        {
            var produtoAbrangencia = ConversorProdutoAbrangencia.Converter(id, produtoAbrangenciaDTO);
           
            return await _repositorioProdutoAbrangencia.Edit(produtoAbrangencia);
        }

        public async Task<ProdutoAbrangenciaDTO> BuscarPeloId(Guid id)
        {
            var produtoAbrangencia = await _repositorioProdutoAbrangencia.BuscarPeloId(id);

            return ConversorProdutoAbrangencia.Converter(produtoAbrangencia);
        }

        public async Task<List<ProdutoAbrangenciaDTO>> BuscarTodos()
        {
            var produtoAbrangencia = await _repositorioProdutoAbrangencia.BuscarTodos();

            return ConversorProdutoAbrangencia.Converter(produtoAbrangencia);
        }

        public async Task<int> Criar(ProdutoAbrangenciaDTO produtoAbrangenciaDTO)
        {
            var produtoAbrangencia = ConversorProdutoAbrangencia.Converter(Guid.NewGuid(), produtoAbrangenciaDTO);
          return await _repositorioProdutoAbrangencia.Criar(produtoAbrangencia);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioProdutoAbrangencia.Excluir(id);
        }
    }
}
