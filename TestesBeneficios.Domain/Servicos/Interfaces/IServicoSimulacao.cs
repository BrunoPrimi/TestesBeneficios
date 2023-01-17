using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoSimulacao
    {
        Task<int> Criar(SimulacaoDTO simulacaoDTO);
        Task<int> Edit(Guid id, SimulacaoDTO simulacaoDTO);
        Task<int> Excluir(Guid id);
        Task<List<SimulacaoDTO>> BuscarTodos();
        Task<SimulacaoDTO> BuscarPeloId(Guid id);
    }
}
