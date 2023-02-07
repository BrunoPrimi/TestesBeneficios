using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Infra.Data.Repositorios.Implementacoes
{
    public class RepositorioSimulacao : IRepositorioSimulacao
    {
        private readonly TesteContext _contexto;

        public RepositorioSimulacao(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(Simulacao simulacao)
        {

            _contexto.Simulacoes.Update(simulacao);

            return await _contexto.SaveChangesAsync();
        }

        public async Task<Simulacao> BuscarPeloId(Guid id)
        {
            return await _contexto.Simulacoes
                .Include(x => x.SimulacaoDistribuicaoVida.OrderBy(x => x.AlcanceInicial))
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Simulacao>> BuscarTodos()
        {
            return await _contexto.Simulacoes.ToListAsync();
        }

        public async Task<List<Produto>> BuscarProduto(Guid id)
        {
            var simulacao=await _contexto.Simulacoes
                .Include(x=>x.SimulacaoDistribuicaoVida)
                .Include(x=>x.SimulacaoAbrangencia)
                .Where(x=>x.Id==id)
                .FirstOrDefaultAsync();


            return await _contexto.Produtos
                .Include(x=>x.FaixaEtaria)
                .Where(x=>x.Abrangencia==simulacao.AbrangenciaProduto)
              
                .ToListAsync();
        }

        public async Task<Guid> Criar(Simulacao simulacao)
        {
            await _contexto.Simulacoes.AddAsync(simulacao);

            await _contexto.SaveChangesAsync();
            return simulacao.Id;
        }

        public async Task<int> CriarDistribuicaoVida(List<SimulacaoDistribuicaoVida> simulacaoDistribuicaoVida)
        {
            var distruicaoBase = await _contexto.DistribuicaoVidas.Where(x => x.IdSimulacao == simulacaoDistribuicaoVida.First().IdSimulacao).ToListAsync();
            _contexto.RemoveRange(distruicaoBase);
            _contexto.AddRange(simulacaoDistribuicaoVida);
        
      return  await _contexto.SaveChangesAsync();
        }
        public async Task<int> Excluir(Guid id)
        {
            var simulacao = await _contexto.Simulacoes.FindAsync(id);

            _contexto.Simulacoes.Remove(simulacao);

            return await _contexto.SaveChangesAsync();
        }
        public async Task<int> ExcluirDistribuicao(Guid id)
        {
            var simulacaodistribuicao = await _contexto.DistribuicaoVidas.FindAsync(id);

            _contexto.DistribuicaoVidas.Remove(simulacaodistribuicao);

            return await _contexto.SaveChangesAsync();
        }

        public async Task <List<SimulacaoDistribuicaoVida>> BuscarDistribuicaoVidaPeloIdSimulaco(Guid idSimulacao)
        {
            return await _contexto.DistribuicaoVidas.Where(x=>x.IdSimulacao==idSimulacao).ToListAsync();
        }
    }
}
