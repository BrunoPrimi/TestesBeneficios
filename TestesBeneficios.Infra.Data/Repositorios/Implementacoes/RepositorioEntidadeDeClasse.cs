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
    public class RepositorioEntidadeDeClasse : IRepositorioEntidadeDeClasse
    {
        private readonly TesteContext _contexto;

        public RepositorioEntidadeDeClasse(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(EntidadeDeClasse entidadeDeClasse )
        {

            _contexto.EntidadeDeClasses.Update(entidadeDeClasse);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<EntidadeDeClasse> BuscarPeloId(Guid id)
        {
          

            return await _contexto.EntidadeDeClasses.FindAsync(id);
        }

        public async Task<List<EntidadeDeClasse>> BuscarTodos()
        {
            return await _contexto.EntidadeDeClasses.ToListAsync();
        }

        public async Task<int> Criar(EntidadeDeClasse entidadeDeClasse)
        {
            await _contexto.EntidadeDeClasses.AddAsync(entidadeDeClasse);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var EntidadeDeClasse = await _contexto.Profissoes.FindAsync(id);

            _contexto.Profissoes.Remove(EntidadeDeClasse);

            return await _contexto.SaveChangesAsync();
        }
    }
}
