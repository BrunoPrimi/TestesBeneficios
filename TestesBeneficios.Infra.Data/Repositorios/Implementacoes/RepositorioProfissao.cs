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
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly TesteContext _contexto;

        public RepositorioEmpresa(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(Empresa empresa )
        {

            _contexto.Empresas.Update(empresa);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<Empresa> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Empresas.FindAsync(id);
        }

        public async Task<List<Empresa>> BuscarTodos()
        {
            return await _contexto.Empresas.ToListAsync();
        }

        public async Task<int> Criar(Empresa empresa)
        {
            await _contexto.Empresas.AddAsync(empresa);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var empresa = await _contexto.Empresas.FindAsync(id);

            _contexto.Empresas.Remove(empresa);

            return await _contexto.SaveChangesAsync();
        }
    }
}
