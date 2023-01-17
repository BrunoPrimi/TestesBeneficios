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
    public class ServicoSimulacaoDistribuicaoVida : IServicoSimulacaoDistribuicaoVida
    {
        private readonly IRepositorioSimulacaoDistribuicaoVida _repositorioSimulacaoDistribuicaoVida;

        public ServicoSimulacaoDistribuicaoVida(IRepositorioSimulacaoDistribuicaoVida repositorioSimulacaoDistribuicaoVida)
        {
            _repositorioSimulacaoDistribuicaoVida = repositorioSimulacaoDistribuicaoVida;
        }
   
        
        public async Task<int> Edit(Guid id , SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO)
        {
            var simulacaoDistribuicaoVida = ConversorSimulacaoDistribuicaoVida.Converter(id, simulacaoDistribuicaoVidaDTO);
           
            return await _repositorioSimulacaoDistribuicaoVida.Edit(simulacaoDistribuicaoVida);
        }

        public async Task<SimulacaoDistribuicaoVidaDTO> BuscarPeloId(Guid id)
        {
            var simulacaoDistribuicaoVida = await _repositorioSimulacaoDistribuicaoVida.BuscarPeloId(id);

            return ConversorSimulacaoDistribuicaoVida.Converter(simulacaoDistribuicaoVida);
        }

        public async Task<List<SimulacaoDistribuicaoVidaDTO>> BuscarTodos()
        {
            var simulacaoDistribuicaoVida = await _repositorioSimulacaoDistribuicaoVida.BuscarTodos();

            return ConversorSimulacaoDistribuicaoVida.Converter(simulacaoDistribuicaoVida);
        }

        public async Task<int> Criar(SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO)
        {
            var simulacaoDistribuicaoVida = ConversorSimulacaoDistribuicaoVida.Converter(Guid.NewGuid(), simulacaoDistribuicaoVidaDTO);
          return await _repositorioSimulacaoDistribuicaoVida.Criar(simulacaoDistribuicaoVida);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioSimulacaoDistribuicaoVida.Excluir(id);
        }
    }
}
