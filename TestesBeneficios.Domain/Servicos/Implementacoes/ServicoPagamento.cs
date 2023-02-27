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
   

        public async Task<int> Edit(Guid id ,EmpresaDTO empresaDTO)
        {
            var empresa = ConversorEmpresa.Converter(id, empresaDTO);
           
            return await _repositorioEmpresa.Edit(empresa);
        }

        public async Task<EmpresaDTO> BuscarPeloId(Guid id)
        {
            var empresa = await _repositorioEmpresa.BuscarPeloId(id);

            return ConversorEmpresa.Converter(empresa);
        }

        public async Task<List<EmpresaDTO>> BuscarTodos()
        {
            var empresas = await _repositorioEmpresa.BuscarTodos();

            return ConversorEmpresa.Converter(empresas);
        }

        public async Task<int> Criar(EmpresaDTO empresaDTO)
        {
            var empresa = ConversorEmpresa.Converter(Guid.NewGuid(), empresaDTO);
          return await  _repositorioEmpresa.Criar(empresa);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioEmpresa.Excluir(id);
        }
    }
}
