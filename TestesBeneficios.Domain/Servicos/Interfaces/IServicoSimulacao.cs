using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoSimulacao
    {
        Task<Guid> Criar(SimulacaoDTO simulacaoDTO);
        Task<int> CriarDistribuicaoVida(List<SimulacaoDistribuicaoVidaDTO> simulacaoDistribucaoVidaDTO);
        Task<int> Edit(Guid id, SimulacaoDTO simulacaoDTO);
        Task<int> Excluir(Guid id);
        Task<List<SimulacaoDTO>> BuscarTodos();
        Task<SimulacaoDTO> BuscarPeloId(Guid id);
    }
}
