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
using TestesBeneficios.Infra.Data.Migrations;

namespace TestesBeneficios.Infra.Data.Repositorios.Implementacoes
{
    public class RepositorioSimulacaoDistribuicaoVida : IRepositorioSimulacaoDistribuicaoVida 
    {
        private readonly TesteContext _contexto;

        public RepositorioSimulacaoDistribuicaoVida(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(SimulacaoDistribuicaoVida simulacaoDistribuicaoVida)
        {

            _contexto.DistribuicaoVidas.Update(simulacaoDistribuicaoVida);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<SimulacaoDistribuicaoVida> BuscarPeloId(Guid id)
        {

            return await _contexto.DistribuicaoVidas.Include(x => x.Simulacao).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<SimulacaoDistribuicaoVida>> BuscarTodos()
        {
            return await _contexto.DistribuicaoVidas.Include(x=>x.Simulacao).ToListAsync();
        }

        public async Task<int> Criar(SimulacaoDistribuicaoVida simulacaoDistribuicaoVida)
        {
            await _contexto.DistribuicaoVidas.AddAsync(simulacaoDistribuicaoVida);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var simulacaoDistribuicaoVida = await _contexto.Abrangencia.FindAsync(id);

            _contexto.Abrangencia.Remove(simulacaoDistribuicaoVida);

            return await _contexto.SaveChangesAsync();
        }
    }
}
