using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorSimulacaoAbrangencia
    {
        public static SimulacaoAbrangencia Converter(Guid id, SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO)
        {
            return new SimulacaoAbrangencia
            {
                Id = id,
                Uf = simulacaoAbrangenciaDTO.Uf,
                Cidade = simulacaoAbrangenciaDTO.Cidade,
                IdSimulacao = simulacaoAbrangenciaDTO.IdSimulacao
            };
        }

        public static SimulacaoAbrangenciaDTO Converter(SimulacaoAbrangencia simulacaoAbrangencia)
        {
            return new SimulacaoAbrangenciaDTO
            {
                Id = simulacaoAbrangencia.Id,
                Uf = simulacaoAbrangencia.Uf,
                Cidade = simulacaoAbrangencia.Cidade,
                IdSimulacao = simulacaoAbrangencia.IdSimulacao
            };
        }

       public static List<SimulacaoAbrangenciaDTO> Converter(List<SimulacaoAbrangencia> simulacaoAbrangencia)
        {
            return simulacaoAbrangencia.Select(x => Converter(x)).ToList();

        }
    }
}
