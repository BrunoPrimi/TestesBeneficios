using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorProfissao
    {
        public static Profissao Converter(Guid id, ProfissaoDTO profissaoDTO)
        {
            return new Profissao
            {
                Id = id,
                Nome = profissaoDTO.Nome,
                DataCriacao = profissaoDTO.DataCriacao
            };
        }

        public static ProfissaoDTO Converter(Profissao profissao)
        {
            if (profissao == null)
            {
                return null;
            }

            return new ProfissaoDTO
            {
                Id = profissao.Id,
                Nome = profissao.Nome,
                DataCriacao = profissao.DataCriacao

            };
        }

       public static List<ProfissaoDTO> Converter(List<Profissao> profissao)
        {
            return profissao.Select(x => Converter(x)).ToList();

        }
    }
}
