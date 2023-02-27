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
    public class ServicoPagamento : IServicoPagamento
    {
        private readonly IRepositorioPagamento _repositorioPagamento;

        public ServicoPagamento(IRepositorioPagamento repositorioPagamento)
        {
            _repositorioPagamento = repositorioPagamento;
        }
   

        public async Task<int> Edit(Guid id ,PagamentoDTO pagamentoDTO)
        {
            var pagamento = ConversorPagamento.Converter(id, pagamentoDTO);
           
            return await _repositorioPagamento.Edit(pagamento);
        }

        public async Task<PagamentoDTO> BuscarPeloId(Guid id)
        {
            var pagamento = await _repositorioPagamento.BuscarPeloId(id);

            return ConversorPagamento.Converter(pagamento);
        }

        public async Task<List<PagamentoDTO>> BuscarTodos()
        {
            var pagamentos = await _repositorioPagamento.BuscarTodos();

            return ConversorPagamento.Converter(pagamentos);
        }

        public async Task<int> Criar(PagamentoDTO pagamentoDTO)
        {
            var pagamento = ConversorPagamento.Converter(Guid.NewGuid(), pagamentoDTO);
          return await  _repositorioPagamento.Criar(pagamento);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioPagamento.Excluir(id);
        }
    }
}
