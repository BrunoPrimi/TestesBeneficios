using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoEntidadeDeClasse
    {
        Task<int> Criar(EntidadeDeClasseDTO entidadeDeClasseDTO);
        Task<int> Edit(Guid id, EntidadeDeClasseDTO entidadeDeClasseDTO);
        Task<int> Excluir(Guid id);
        Task<List<EntidadeDeClasseDTO>> BuscarTodos();
        Task<EntidadeDeClasseDTO> BuscarPeloId(Guid id);
    }
}
