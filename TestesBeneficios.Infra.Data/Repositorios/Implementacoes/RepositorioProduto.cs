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
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly TesteContext _contexto;

        public RepositorioProduto(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(Produto produto )
        {

            _contexto.Produtos.Update(produto);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<Produto> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> BuscarTodos()
        {
            return await _contexto.Produtos.ToListAsync();
        }

        public async Task<int> Criar(Produto produto)
        {
            await _contexto.Produtos.AddAsync(produto);
          
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
