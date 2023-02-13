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
    public class RepositorioDeclaracaoDeSaude : IRepositorioDeclaracaoDeSaude
    {
        private readonly TesteContext _contexto;

        public RepositorioDeclaracaoDeSaude(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(DeclaracaoDeSaude declaracaoDeSaude )
        {

            _contexto.DeclaracaoDeSaudes.Update(declaracaoDeSaude);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<DeclaracaoDeSaude> BuscarPeloId(Guid id)
        {
          

            return await _contexto.DeclaracaoDeSaudes.FindAsync(id);
        }

        public async Task<List<DeclaracaoDeSaude>> BuscarTodos()
        {
            return await _contexto.DeclaracaoDeSaudes.ToListAsync();
        }

        public async Task<int> Criar(DeclaracaoDeSaude declaracaoDeSaude)
        {
            await _contexto.DeclaracaoDeSaudes.AddAsync(declaracaoDeSaude);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var declaracaoDeSaude = await _contexto.DeclaracaoDeSaudes.FindAsync(id);

            _contexto.DeclaracaoDeSaudes.Remove(declaracaoDeSaude);

            return await _contexto.SaveChangesAsync();
        }
    }
}
