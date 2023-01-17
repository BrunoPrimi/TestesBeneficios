using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoProfissao
    {
        Task<int> Criar(ProfissaoDTO profissaoDTO);
        Task<int> Edit(Guid id, ProfissaoDTO profissaoDTO);
        Task<int> Excluir(Guid id);
        Task<List<ProfissaoDTO>> BuscarTodos();
        Task<ProfissaoDTO> BuscarPeloId(Guid id);
    }
}
