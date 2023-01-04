using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoProduto
    {
        Task<int> Criar(ProdutoDTO produtoDTO);
        Task<int> Edit(Guid id, ProdutoDTO produtoDTO);
        Task<int> Excluir(Guid id);
        Task<List<ProdutoDTO>> BuscarTodos();
        Task<ProdutoDTO> BuscarPeloId(Guid id);
    }
}
