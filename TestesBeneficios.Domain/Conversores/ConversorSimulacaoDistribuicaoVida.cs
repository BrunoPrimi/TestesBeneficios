using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorSimulacaoDistribuicaoVida
    {
        public static SimulacaoDistribuicaoVida Conversor(Guid id, SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO)
        {
            return new SimulacaoDistribuicaoVida
            {
                Id = id,
                AlcanceInicial = simulacaoDistribuicaoVidaDTO.AlcanceInicial,
                AlcanceFinal = simulacaoDistribuicaoVidaDTO.AlcanceFinal,
                Quantidade = simulacaoDistribuicaoVidaDTO.Quantidade,
                IdSimulacao = simulacaoDistribuicaoVidaDTO.IdSimulacao
            };
        }

        public static SimulacaoDistribuicaoVidaDTO Converter(SimulacaoDistribuicaoVida simulacaoDistribuicaoVida)
        {
            return new SimulacaoDistribuicaoVidaDTO
            {
                Id = simulacaoDistribuicaoVida.Id,
                AlcanceInicial = simulacaoDistribuicaoVida.AlcanceInicial,
                AlcanceFinal = simulacaoDistribuicaoVida.AlcanceFinal,
                Quantidade = simulacaoDistribuicaoVida.Quantidade,
                IdSimulacao = simulacaoDistribuicaoVida.IdSimulacao
            };
        }

       public static List<SimulacaoDistribuicaoVidaDTO> Converter(List<SimulacaoDistribuicaoVida> simulacaoDistribuicaoVida)
        {
            return simulacaoDistribuicaoVida.Select(x => Converter(x)).ToList();

        }
    }
}
