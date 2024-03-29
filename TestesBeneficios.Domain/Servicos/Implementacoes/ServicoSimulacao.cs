﻿using System;
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


        public async Task<int> Edit(Guid id, SimulacaoDTO SimulacaoDTO)
        {
            var Simulacao = ConversorSimulacao.Converter(id, SimulacaoDTO);

            return await _repositorioSimulacao.Edit(Simulacao);
        }

        public async Task<SimulacaoDTO> BuscarPeloId(Guid id)
        {
            var simulacao = await _repositorioSimulacao.BuscarPeloId(id);
            return ConversorSimulacao.Converter(simulacao);
        }
        public async Task<List<ProdutoDTO>> BuscarProduto(Guid id)
        {
            var produtos = await _repositorioSimulacao.BuscarProduto(id);
            var produtosDTO = ConversorProduto.Converter(produtos);
            var simulacao = await _repositorioSimulacao.BuscarPeloId(id);
            foreach (var produtoDTO in produtosDTO) {
                foreach (var item in simulacao.SimulacaoDistribuicaoVida.Where(x => x.Quantidade > 0))
                {
                    produtoDTO.Preco = produtoDTO.Preco == null ? 0 : produtoDTO.Preco;
                    produtoDTO.Preco = produtoDTO.Preco + produtoDTO.FaixaEtaria.Where(x => x.FaixaDe == Convert.ToInt32(item.AlcanceInicial)
                    && x.FaixaAte == Convert.ToInt32(item.AlcanceFinal)
                    ).Sum(x => x.Preco);

                }
            }
            return produtosDTO;
        }

        public async Task<List<SimulacaoDTO>> BuscarTodos()
        {
            var simulacaos = await _repositorioSimulacao.BuscarTodos();

            return ConversorSimulacao.Converter(simulacaos);
        }

        public async Task<Guid> Criar(SimulacaoDTO SimulacaoDTO)
        {
            var Simulacao = ConversorSimulacao.Converter(Guid.NewGuid(), SimulacaoDTO);
            return await _repositorioSimulacao.Criar(Simulacao);
        }

        public async Task<int> CriarDistribuicaoVida(List<SimulacaoDistribuicaoVidaDTO> simulacaoDistribuicaoVidaDTO)
        {
            var distribuicaovida = await _repositorioSimulacao.BuscarDistribuicaoVidaPeloIdSimulaco(simulacaoDistribuicaoVidaDTO.FirstOrDefault().IdSimulacao);
            foreach (var item in distribuicaovida)
            {
                await _repositorioSimulacao.ExcluirDistribuicao(item.Id);
            }
            var simulacaoDistribuicaoVida = ConversorSimulacao.Converter(simulacaoDistribuicaoVidaDTO);
            return await _repositorioSimulacao.CriarDistribuicaoVida(simulacaoDistribuicaoVida);
        }

        public async Task<int> Excluir(Guid id)
        {
            return await _repositorioSimulacao.Excluir(id);
        }

    }
}
