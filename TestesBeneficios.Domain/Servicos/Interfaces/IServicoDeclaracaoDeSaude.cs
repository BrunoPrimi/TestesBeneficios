using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoDeclaracaoDeSaude
    {
        Task<int> Criar(DeclaracaoDeSaudeDTO declaracaoDeSaudeDTO);
        Task<int> Edit(Guid id, DeclaracaoDeSaudeDTO declaracaoDeSaudeDTO);
        Task<int> Excluir(Guid id);
        Task<List<DeclaracaoDeSaudeDTO>> BuscarTodos();
        Task<DeclaracaoDeSaudeDTO> BuscarPeloId(Guid id);
    }
}
