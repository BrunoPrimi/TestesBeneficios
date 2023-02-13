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
    public class ServicoDeclaracaoDeSaude: IServicoDeclaracaoDeSaude
    {
        private readonly IRepositorioDeclaracaoDeSaude _repositorioDeclaracaoDeSaude;

        public ServicoDeclaracaoDeSaude(IRepositorioDeclaracaoDeSaude repositorioDeclaracaoDeSaude)
        {
            _repositorioDeclaracaoDeSaude = repositorioDeclaracaoDeSaude;
        }
   

        public async Task<int> Edit(Guid id ,DeclaracaoDeSaudeDTO declaracaoDeSaudeDTO)
        {
            var declaracaoDeSaude = ConversorDeclaracaoDeSaude.Converter(id, declaracaoDeSaudeDTO);
           
            return await _repositorioDeclaracaoDeSaude.Edit(declaracaoDeSaude);
        }

        public async Task<DeclaracaoDeSaudeDTO> BuscarPeloId(Guid id)
        {
            var declaracaoDeSaude = await _repositorioDeclaracaoDeSaude.BuscarPeloId(id);

            return ConversorDeclaracaoDeSaude.Converter(declaracaoDeSaude);
        }

        public async Task<List<DeclaracaoDeSaudeDTO>> BuscarTodos()
        {
            var declaracaoDeSaudes = await _repositorioDeclaracaoDeSaude.BuscarTodos();

            return ConversorDeclaracaoDeSaude.Converter(declaracaoDeSaudes);
        }

        public async Task<int> Criar(DeclaracaoDeSaudeDTO declaracaoDeSaudeDTO)
        {
            var declaracaoDeSaude = ConversorDeclaracaoDeSaude.Converter(Guid.NewGuid(), declaracaoDeSaudeDTO);
          return await  _repositorioDeclaracaoDeSaude.Criar(declaracaoDeSaude);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioDeclaracaoDeSaude.Excluir(id);
        }
    }
}
