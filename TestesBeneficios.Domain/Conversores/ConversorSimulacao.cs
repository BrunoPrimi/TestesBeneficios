using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorSimulacao
    {
        public static Simulacao Converter(Guid id, SimulacaoDTO simulacaoDTO)
        {
            return new Simulacao
            {
                Id = id,
                Nome = simulacaoDTO.Nome,
                Email = simulacaoDTO.Email,
                Cpf = simulacaoDTO.Cpf,
                IdProfissao = simulacaoDTO.IdProfissao,
                IdEntidadeDeClasse = simulacaoDTO.IdEntidadeDeClasse
            };
        }
      public static List<SimulacaoDistribuicaoVida> Converter(List<SimulacaoDistribuicaoVidaDTO> simulacaoDistribuicaoVidaDTO)
        {
            return simulacaoDistribuicaoVidaDTO.Select(x => new SimulacaoDistribuicaoVida
            {
                Id = Guid.NewGuid(),
                AlcanceInicial = x.AlcanceInicial,
                AlcanceFinal = x.AlcanceFinal,
                Quantidade = x.Quantidade,
                IdSimulacao = x.IdSimulacao
    }).ToList();
        }
     

        public static List<SimulacaoDTO> Converter(List<Simulacao> Simulacaos)
        {
            return Simulacaos.Select(x => Converter(x)).ToList();

        }

        public static SimulacaoDTO Converter(Simulacao simulacao)
        {
            SimulacaoDTO simulacaoDTO = null;

            if (simulacao != null)
            {
                simulacaoDTO = new SimulacaoDTO
                {
                    Id = simulacao.Id,
                    Nome = simulacao.Nome,
                    Email = simulacao.Email,
                    Cpf = simulacao.Cpf,
                    IdProfissao = simulacao.IdProfissao,
                    IdEntidadeDeClasse = simulacao.IdEntidadeDeClasse,
                    Profissao = ConversorProfissao.Converter(simulacao.Profissao),
                    EntidadeDeClasse = ConversorEntidadeDeClasse.Converter(simulacao.EntidadeDeClasse),
                    SimulacaoDistribuicaoVida = ConversorSimulacaoDistribuicaoVida.Converter(simulacao.SimulacaoDistribuicaoVida),
                };
            }

            return simulacaoDTO;
        }
    }
}
