using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoSimulacaoDistribuicaoVida
    {
        Task<int> Criar(SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO);
        Task<int> Edit(Guid id, SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO);
        Task<int> Excluir(Guid id);
        Task<List<SimulacaoDistribuicaoVidaDTO>> BuscarTodos();
        Task<SimulacaoDistribuicaoVidaDTO> BuscarPeloId(Guid id);
    }
}
