using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioDeclaracaoDeSaude
    {
        Task<int> Criar(DeclaracaoDeSaude declaracaoDeSaude);
        Task<int> Edit(DeclaracaoDeSaude declaracaoDeSaude);
        Task<int> Excluir(Guid id);
        Task<List<DeclaracaoDeSaude>> BuscarTodos();
        Task<DeclaracaoDeSaude> BuscarPeloId(Guid id);    
    }
}
