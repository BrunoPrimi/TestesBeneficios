using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Convercores;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Interfaces;

namespace TestesBeneficios.Domain.Servicos.Implementacoes
{
    public class ServicoEmpresa : IServicoEmpresa
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
        }
   

        public async Task<int> Atualizar(Guid id, EmpresaDTO empresaDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<EmpresaDTO> BuscarPeloId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmpresaDTO>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Criar(EmpresaDTO empresaDTO)
        {
            var empresa = ConversorEmpresa.Converter(Guid.NewGuid(), empresaDTO);
          return await  _repositorioEmpresa.Criar(empresa);
        }

        public async Task<int> Excluir(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
