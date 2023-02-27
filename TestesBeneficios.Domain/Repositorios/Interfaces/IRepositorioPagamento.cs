using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioPagamento
    {
        Task<int> Criar(Pagamento pagamento);
        Task<int> Edit(Pagamento pagamento);
        Task<int> Excluir(Guid id);
        Task<List<Pagamento>> BuscarTodos();
        Task<Pagamento> BuscarPeloId(Guid id);    
    }
}
