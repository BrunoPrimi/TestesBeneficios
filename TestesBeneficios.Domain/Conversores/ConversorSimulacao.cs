﻿using System;
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

        public static SimulacaoDTO Converter(Simulacao simulacao)
        {
            if (simulacao == null)
            {
                return null;
            }
            return new SimulacaoDTO
            {
                Id = simulacao.Id,
                Nome = simulacao.Nome,
                Email = simulacao.Email,
                Cpf = simulacao.Cpf,
                IdProfissao = simulacao.IdProfissao,
                IdEntidadeDeClasse = simulacao.IdEntidadeDeClasse

            };
        }

        public static List<SimulacaoDTO> Converter(List<Simulacao> Simulacaos)
        {
            return Simulacaos.Select(x => Converter(x)).ToList();

        }
    }
}