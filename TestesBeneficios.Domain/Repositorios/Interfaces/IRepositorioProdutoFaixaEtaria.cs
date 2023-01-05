using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioProdutoFaixaEtaria
    {
        Task<int> Criar(ProdutoFaixaEtaria produtoFaixaEtaria);
        Task<int> Edit(ProdutoFaixaEtaria produtoFaixaEtaria);
        Task<int> Excluir(Guid id);
        Task<List<ProdutoFaixaEtaria>> BuscarTodos();
        Task<ProdutoFaixaEtaria> BuscarPeloId(Guid id);    
    }
}
