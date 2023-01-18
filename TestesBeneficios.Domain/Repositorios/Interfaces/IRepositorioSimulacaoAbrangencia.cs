using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioSimulacaoAbrangencia
    {
        Task<int> Criar(SimulacaoAbrangencia simulacaoAbrangencia);
        Task<int> Edit(SimulacaoAbrangencia simulacaoAbrangencia);
        Task<int> Excluir(Guid id);
        Task<List<SimulacaoAbrangencia>> BuscarTodos();
        Task<SimulacaoAbrangencia> BuscarPeloId(Guid id);    
    }
}
