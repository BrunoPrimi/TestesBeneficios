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
    public class RepositorioSimulacaoAbrangencia : IRepositorioSimulacaoAbrangencia 
    {
        private readonly TesteContext _contexto;

        public RepositorioSimulacaoAbrangencia(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(SimulacaoAbrangencia simulacaoAbrangencia)
        {

            _contexto.Abrangencias.Update(simulacaoAbrangencia);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<SimulacaoAbrangencia> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Abrangencias.Include(x => x.Simulacao).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<SimulacaoAbrangencia>> BuscarTodos()
        {
            return await _contexto.Abrangencias.Include(x=>x.Simulacao).ToListAsync();
        }

        public async Task<int> Criar(SimulacaoAbrangencia simulacaoAbrangencia)
        {
            await _contexto.Abrangencias.AddAsync(simulacaoAbrangencia);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var simulacaoAbrangencia = await _contexto.Abrangencia.FindAsync(id);

            _contexto.Abrangencia.Remove(simulacaoAbrangencia);

            return await _contexto.SaveChangesAsync();
        }
    }
}
