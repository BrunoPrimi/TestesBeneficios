using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioProduto
    {
        Task<int> Criar(Produto produto);
        Task<int> Edit(Produto produto);
        Task<int> Excluir(Guid id);
        Task<List<Produto>> BuscarTodos();
        Task<Produto> BuscarPeloId(Guid id);    
    }
}
