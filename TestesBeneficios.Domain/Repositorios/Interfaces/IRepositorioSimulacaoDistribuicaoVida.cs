using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioSimulacaoDistribuicaoVida
    {
        Task<int> Criar(SimulacaoDistribuicaoVida simulacaoDistribuicaoVida);
        Task<int> Edit(SimulacaoDistribuicaoVida simulacaoDistribuicaoVida);
        Task<int> Excluir(Guid id);
        Task<List<SimulacaoDistribuicaoVida>> BuscarTodos();
        Task<SimulacaoDistribuicaoVida> BuscarPeloId(Guid id);    
    }
}
