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
    public class ServicoEntidadeDeClasse : IServicoEntidadeDeClasse

    { 
        private readonly IRepositorioEntidadeDeClasse _repositorioEntidadeDeClasse;

        public ServicoEntidadeDeClasse(IRepositorioEntidadeDeClasse repositorioEntidadeDeClasse)
        {
        _repositorioEntidadeDeClasse = repositorioEntidadeDeClasse;
        }
   

        public async Task<int> Edit(Guid id ,EntidadeDeClasseDTO EntidadeDeClasseDTO)
        {
            var EntidadeDeClasse = ConversorEntidadeDeClasse.Converter(id, EntidadeDeClasseDTO);
           
            return await _repositorioEntidadeDeClasse.Edit(EntidadeDeClasse);
        }

        public async Task<EntidadeDeClasseDTO> BuscarPeloId(Guid id)
        {
            var EntidadeDeClasse = await _repositorioEntidadeDeClasse.BuscarPeloId(id);

            return ConversorEntidadeDeClasse.Converter(EntidadeDeClasse);
        }

        public async Task<List<EntidadeDeClasseDTO>> BuscarTodos()
        {
            var EntidadeDeClasse = await _repositorioEntidadeDeClasse.BuscarTodos();

            return ConversorEntidadeDeClasse.Converter(EntidadeDeClasse);
        }

        public async Task<int> Criar(EntidadeDeClasseDTO EntidadeDeClasseDTO)
        {
            var EntidadeDeClasse = ConversorEntidadeDeClasse.Converter(Guid.NewGuid(), EntidadeDeClasseDTO);
          return await  _repositorioEntidadeDeClasse.Criar(EntidadeDeClasse);
        }

        public async Task<int> Excluir(Guid id)
        {

            return await _repositorioEntidadeDeClasse.Excluir(id);
        }
    }
}

