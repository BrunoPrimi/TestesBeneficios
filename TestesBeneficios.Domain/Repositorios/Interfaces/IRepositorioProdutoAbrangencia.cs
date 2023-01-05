using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioProdutoAbrangencia
    {
        Task<int> Criar(ProdutoAbrangencia ptodutoAbrangencia);
        Task<int> Edit(ProdutoAbrangencia produtoAbrangencia);
        Task<int> Excluir(Guid id);
        Task<List<ProdutoAbrangencia>> BuscarTodos();
        Task<ProdutoAbrangencia> BuscarPeloId(Guid id);    
    }
}
