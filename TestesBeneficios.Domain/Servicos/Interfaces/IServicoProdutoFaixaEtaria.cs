using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoProdutoFaixaEtaria
    {
        Task<int> Criar(ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO);
        Task<int> Edit(Guid id, ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO);
        Task<int> Excluir(Guid id);
        Task<List<ProdutoFaixaEtariaDTO>> BuscarTodos();
        Task<ProdutoFaixaEtariaDTO> BuscarPeloId(Guid id);
    }
}
