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
    public class ServicoSimulcao : IServicoSimulacao
    {
        private readonly IRepositorioSimulacao _repositorioSimulacao;

        public ServicoSimulcao(IRepositorioSimulacao repositorioSimulacao)
        {
            _repositorioSimulacao = repositorioSimulacao;
        }
   

        public async Task<int> Edit(Guid id ,SimulacaoDTO SimulacaoDTO)
        {
            var Simulacao = ConversorSimulacao.Converter(id, SimulacaoDTO);
           
            return await _repositorioSimulacao.Edit(Simulacao);
        }

        public async Task<SimulacaoDTO> BuscarPeloId(Guid id)
        {
            var Simulacao = await _repositorioSimulacao.BuscarPeloId(id);

            return ConversorSimulacao.Converter(Simulacao);
        }

        public async Task<List<SimulacaoDTO>> BuscarTodos()
        {
            var Simulacaos = await _repositorioSimulacao.BuscarTodos();

            return ConversorSimulacao.Converter(Simulacaos);
        }

        public async Task<int> Criar(SimulacaoDTO SimulacaoDTO)
        {
            var Simulacao = ConversorSimulacao.Converter(Guid.NewGuid(), SimulacaoDTO);
          return await _repositorioSimulacao.Criar(Simulacao);
        }

        public async Task<int> Excluir(Guid id)
        {
            return await _repositorioSimulacao.Excluir(id);
        }
    }
}
