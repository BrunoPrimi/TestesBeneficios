using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioEntidadeDeClasse
    {
        Task<int> Criar(EntidadeDeClasse entidadeDeClasse);
        Task<int> Edit(EntidadeDeClasse entidadeDeClasse);
        Task<int> Excluir(Guid id);
        Task<List<EntidadeDeClasse>> BuscarTodos();
        Task<EntidadeDeClasse> BuscarPeloId(Guid id);    
    }
}
