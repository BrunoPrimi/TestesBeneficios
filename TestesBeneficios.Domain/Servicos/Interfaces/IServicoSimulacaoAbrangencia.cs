using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoSimulacaoAbrangencia
    {
        Task<int> Criar(SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO);
        Task<int> Edit(Guid id, SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO);
        Task<int> Excluir(Guid id);
        Task<List<SimulacaoAbrangenciaDTO>> BuscarTodos();
        Task<SimulacaoAbrangenciaDTO> BuscarPeloId(Guid id);
    }
}
