using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoPagamento
    {
        Task<int> Criar(PagamentoDTO pagamentoDTO);
        Task<int> Edit(Guid id, PagamentoDTO pagamentoDTO);
        Task<int> Excluir(Guid id);
        Task<List<PagamentoDTO>> BuscarTodos();
        Task<PagamentoDTO> BuscarPeloId(Guid id);
    }
}
