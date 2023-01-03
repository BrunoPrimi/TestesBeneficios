using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Servicos.Interfaces
{
   public interface IServicoEmpresa
    {
        Task<int> Criar(EmpresaDTO empresaDTO);
        Task<int> Atualizar(Guid id, EmpresaDTO empresaDTO);
        Task<int> Excluir(Guid id);
        Task<List<EmpresaDTO>> BuscarTodos();
        Task<EmpresaDTO> BuscarPeloId(Guid id);
    }
}
