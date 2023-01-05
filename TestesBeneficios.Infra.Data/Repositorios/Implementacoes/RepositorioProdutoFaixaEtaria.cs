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
    public class RepositorioProdutoFaixaEtaria : IRepositorioProdutoFaixaEtaria
    {
        private readonly TesteContext _contexto;

        public RepositorioProdutoFaixaEtaria(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(ProdutoFaixaEtaria produtoFaixaEtaria)
        {

            _contexto.FaixaEtaria.Update(produtoFaixaEtaria);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<ProdutoFaixaEtaria> BuscarPeloId(Guid id)
        {
          

            return await _contexto.FaixaEtaria.Include(x => x.Produto).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<ProdutoFaixaEtaria>> BuscarTodos()
        {
            return await _contexto.FaixaEtaria.Include(x=>x.Produto).ToListAsync();
        }

        public async Task<int> Criar(ProdutoFaixaEtaria produtoFaixaEtaria)
        {
            await _contexto.FaixaEtaria.AddAsync(produtoFaixaEtaria);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var produtoFaixaEtaria = await _contexto.FaixaEtaria.FindAsync(id);

            _contexto.FaixaEtaria.Remove(produtoFaixaEtaria);

            return await _contexto.SaveChangesAsync();
        }
    }
}
