﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioSimulacao
    {
        Task<Guid> Criar(Simulacao simulacao);

        Task<int> Edit(Simulacao simulacao);
        Task<int> Excluir(Guid id);
        Task<int> ExcluirDistribuicao(Guid id);
        Task<List<Simulacao>> BuscarTodos();
        Task<Simulacao> BuscarPeloId(Guid id);
        Task<List<Produto>> BuscarProduto(Guid id);
        Task<List<SimulacaoDistribuicaoVida>> BuscarDistribuicaoVidaPeloIdSimulaco(Guid idSimulacao);

        Task<int> CriarDistribuicaoVida(List<SimulacaoDistribuicaoVida> simulacaoDistribucaoVida);
    }
}
