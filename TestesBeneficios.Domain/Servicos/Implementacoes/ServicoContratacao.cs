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
    public class ServicoContratacao : IServicoContratacao
    {
        private readonly IRepositorioContratacao _repositorioContratacao;

        public ServicoContratacao(IRepositorioContratacao repositorioContratacao)
        {
            _repositorioContratacao = repositorioContratacao;
        }


        public async Task<int> Edit(Guid id, ContratacaoDTO contratacaoDTO)
        {
            var contratacao = ConversorContratacao.Converter(id, contratacaoDTO);

            return await _repositorioContratacao.Edit(contratacao);
        }

        public async Task<ContratacaoDTO> BuscarPeloId(Guid id)
        {
            var contratacao = await _repositorioContratacao.BuscarPeloId(id);
            return ConversorContratacao.Converter(contratacao);
        }
       

        public async Task<List<ContratacaoDTO>> BuscarTodos()
        {
            var contratacaos = await _repositorioContratacao.BuscarTodos();

            return ConversorContratacao.Converter(contratacaos);
        }

        public async Task<Guid> Criar(ContratacaoDTO contratacaoDTO)
        {
            var contratacao = ConversorContratacao.Converter(Guid.NewGuid(), contratacaoDTO);
            return await _repositorioContratacao.Criar(contratacao);
        }

      
        public async Task<int> Excluir(Guid id)
        {
            return await _repositorioContratacao.Excluir(id);
        }

    }
}
