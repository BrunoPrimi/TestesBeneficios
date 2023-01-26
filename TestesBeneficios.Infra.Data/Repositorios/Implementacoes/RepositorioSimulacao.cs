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

        public async Task<int> Edit(Simulacao simulacao )
        {

            _contexto.Simulacoes.Update(simulacao);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<Simulacao> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Simulacoes.FindAsync(id);
        }

        public async Task<List<Simulacao>> BuscarTodos()
        {
            return await _contexto.Simulacoes.ToListAsync();
        }

        public async Task<Guid> Criar(Simulacao simulacao)
        {
            await _contexto.Simulacoes.AddAsync(simulacao);
          
            await _contexto.SaveChangesAsync();
            return simulacao.Id;
        }

        public async Task<int> Excluir(Guid id)
        {
            var simulacao = await _contexto.Simulacoes.FindAsync(id);

            _contexto.Simulacoes.Remove(simulacao);

            return await _contexto.SaveChangesAsync();
        }
    }
}
