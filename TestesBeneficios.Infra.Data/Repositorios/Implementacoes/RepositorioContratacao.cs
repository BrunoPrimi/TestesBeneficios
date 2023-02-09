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
    public class RepositorioContratacao: IRepositorioContratacao
    {
        private readonly TesteContext _contexto;

        public RepositorioContratacao(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(Contratacao contratacao)
        {

            _contexto.Contratacoes.Update(contratacao);

            return await _contexto.SaveChangesAsync();
        }

        public async Task<Contratacao> BuscarPeloId(Guid id)
        {
            return await _contexto.Contratacoes
                .Include(x => x.ContratacaoDistribuicaoVida.OrderBy(x => x.AlcanceInicial))
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Contratacao>> BuscarTodos()
        {
            return await _contexto.Contratacoes.ToListAsync();
        }

       
        public async Task<Guid> Criar(Contratacao contratacao)
        {
            await _contexto.Contratacoes.AddAsync(contratacao);

            await _contexto.SaveChangesAsync();
            return contratacao.Id;
        }

      
        public async Task<int> Excluir(Guid id)
        {
            var contratacao = await _contexto.Contratacoes.FindAsync(id);

            _contexto.Simulacoes.Remove(contratacao);

            return await _contexto.SaveChangesAsync();
        }
        public async Task<int> ExcluirDistribuicao(Guid id)
        {
            var contratacaodistribuicao = await _contexto.DistribuicaoVidas.FindAsync(id);

            _contexto.DistribuicaoVidas.Remove(contratacaodistribuicao);

            return await _contexto.SaveChangesAsync();
        }

      
    }
}
