using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoProdutoAbrangencia
    {
        Task<int> Criar(ProdutoAbrangenciaDTO produtoAbrangenciaDTO);
        Task<int> Edit(Guid id, ProdutoAbrangenciaDTO produtoAbrangenciaDTO);
        Task<int> Excluir(Guid id);
        Task<List<ProdutoAbrangenciaDTO>> BuscarTodos();
        Task<ProdutoAbrangenciaDTO> BuscarPeloId(Guid id);
    }
}
