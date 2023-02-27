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
    public class RepositorioPagamento : IRepositorioPagamento
    {
        private readonly TesteContext _contexto;

        public RepositorioPagamento(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(Pagamento pagamento )
        {

            _contexto.Pagamentos.Update(pagamento);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<Pagamento> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Pagamentos.FindAsync(id);
        }

        public async Task<List<Pagamento>> BuscarTodos()
        {
            return await _contexto.Pagamentos.ToListAsync();
        }

        public async Task<int> Criar(Pagamento pagamento)
        {
            await _contexto.Pagamentos.AddAsync(pagamento);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var pagamento = await _contexto.Pagamentos.FindAsync(id);

            _contexto.Pagamentos.Remove(pagamento);

            return await _contexto.SaveChangesAsync();
        }
    }
}
