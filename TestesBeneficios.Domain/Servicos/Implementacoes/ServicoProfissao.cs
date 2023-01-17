using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Convercores;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Interfaces;

namespace TestesBeneficios.Domain.Servicos.Implementacoes
{
    public class ServicoProfisssao : IServicoProfissao
    { 
        private readonly IRepositorioProfissao _repositorioProfissao;

        public ServicoProfisssao(IRepositorioProfissao repositorioProfissao)
        {
        _repositorioProfissao = repositorioProfissao;
        }
   

        public async Task<int> Edit(Guid id ,ProfissaoDTO profissaoDTO)
        {
            var profissao = ConversorProfissao.Converter(id, profissaoDTO);
           
            return await _repositorioProfissao.Edit(profissao);
        }

        public async Task<ProfissaoDTO> BuscarPeloId(Guid id)
        {
            var profissao = await _repositorioProfissao.BuscarPeloId(id);

            return ConversorProfissao.Converter(profissao);
        }

        public async Task<List<ProfissaoDTO>> BuscarTodos()
        {
            var profissao = await _repositorioProfissao.BuscarTodos();

            return ConversorProfissao.Converter(profissao);
        }

        public async Task<int> Criar(ProfissaoDTO profissaoDTO)
        {
            var profissao = ConversorProfissao.Converter(Guid.NewGuid(), profissaoDTO);
          return await  _repositorioProfissao.Criar(profissao);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioProfissao.Excluir(id);
        }
    }
}

