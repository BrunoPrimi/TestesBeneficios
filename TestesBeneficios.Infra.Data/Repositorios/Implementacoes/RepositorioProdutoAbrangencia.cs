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
    public class RepositorioProdutoAbrangencia : IRepositorioProdutoAbrangencia 
    {
        private readonly TesteContext _contexto;

        public RepositorioProdutoAbrangencia(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(ProdutoAbrangencia produtoAbrangencia)
        {

            _contexto.Abrangencia.Update(produtoAbrangencia);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<ProdutoAbrangencia> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Abrangencia.Include(x => x.Produto).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<ProdutoAbrangencia>> BuscarTodos()
        {
            return await _contexto.Abrangencia.Include(x=>x.Produto).ToListAsync();
        }

        public async Task<int> Criar(ProdutoAbrangencia produtoAbrangencia)
        {
            await _contexto.Abrangencia.AddAsync(produtoAbrangencia);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var produtoAbrangencia = await _contexto.Abrangencia.FindAsync(id);

            _contexto.Abrangencia.Remove(produtoAbrangencia);

            return await _contexto.SaveChangesAsync();
        }
    }
}
