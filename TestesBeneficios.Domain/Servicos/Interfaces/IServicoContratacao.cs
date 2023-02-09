using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoContratacao    {
        Task<Guid> Criar(ContratacaoDTO contratacaoDTO);
        Task<int> Edit(Guid id, ContratacaoDTO contratacaoDTO);
        Task<int> Excluir(Guid id);
        Task<List<ContratacaoDTO>> BuscarTodos();
        Task<ContratacaoDTO> BuscarPeloId(Guid id);
    }
}
