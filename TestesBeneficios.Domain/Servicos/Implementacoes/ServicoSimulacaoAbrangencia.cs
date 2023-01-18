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
    public class ServicoSimulacaoAbrangencia : IServicoSimulacaoAbrangencia
    {
        private readonly IRepositorioSimulacaoAbrangencia _repositorioSimulacaoAbrangencia;

        public ServicoSimulacaoAbrangencia(IRepositorioSimulacaoAbrangencia repositorioSimulacaoAbrangencia)
        {
            _repositorioSimulacaoAbrangencia = repositorioSimulacaoAbrangencia;
        }
   
        
        public async Task<int> Edit(Guid id , SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO)
        {
            var simulacaoAbrangencia = ConversorSimulacaoAbrangencia.Converter(id, simulacaoAbrangenciaDTO);
           
            return await _repositorioSimulacaoAbrangencia.Edit(simulacaoAbrangencia);
        }

        public async Task<SimulacaoAbrangenciaDTO> BuscarPeloId(Guid id)
        {
            var simulacaoAbrangencia = await _repositorioSimulacaoAbrangencia.BuscarPeloId(id);

            return ConversorSimulacaoAbrangencia.Converter(simulacaoAbrangencia);
        }

        public async Task<List<SimulacaoAbrangenciaDTO>> BuscarTodos()
        {
            var simulacaoAbrangencia = await _repositorioSimulacaoAbrangencia.BuscarTodos();

            return ConversorSimulacaoAbrangencia.Converter(simulacaoAbrangencia);
        }

        public async Task<int> Criar(SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO)
        {
            var simulacaoAbrangencia = ConversorSimulacaoAbrangencia.Converter(Guid.NewGuid(), simulacaoAbrangenciaDTO);
          return await _repositorioSimulacaoAbrangencia.Criar(simulacaoAbrangencia);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioSimulacaoAbrangencia.Excluir(id);
        }
    }
}
