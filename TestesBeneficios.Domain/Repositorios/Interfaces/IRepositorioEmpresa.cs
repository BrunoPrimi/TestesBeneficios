using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioEmpresa 
    {
        Task<int> Criar(Empresa empresa);
        Task<int> Atualizar(Empresa empresa);
        Task<int> Excluir(Guid id);
        Task<List<Empresa>> BuscarTodos();
        Task<Empresa> BuscarPeloId(Guid id);
    }
}
