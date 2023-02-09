using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioContratacao
    {
        Task<Guid> Criar(Contratacao contratacao);

        Task<int> Edit(Contratacao contratacao);
        Task<int> Excluir(Guid id);
        Task<int> ExcluirDistribuicao(Guid id);
        Task<List<Contratacao>> BuscarTodos();
        Task<Contratacao> BuscarPeloId(Guid id);
        
    }
}
