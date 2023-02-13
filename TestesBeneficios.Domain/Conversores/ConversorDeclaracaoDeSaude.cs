using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorDeclaracaoDeSaude
    {
        public static DeclaracaoDeSaude Converter(Guid id, DeclaracaoDeSaudeDTO declaracaoDeSaudeDTO)
        {
            return new DeclaracaoDeSaude
            {
                Id = id,
                Detalhes = declaracaoDeSaudeDTO.Detalhes,
                Resposta = declaracaoDeSaudeDTO.Resposta,
                DataDoEvento = declaracaoDeSaudeDTO.DataDoEvento
            };
        }

        public static DeclaracaoDeSaudeDTO Converter(DeclaracaoDeSaude declaracaoDeSaude)
        {
            return new DeclaracaoDeSaudeDTO
            {
                Id = declaracaoDeSaude.Id,
                Detalhes = declaracaoDeSaude.Detalhes,
                Resposta = declaracaoDeSaude.Resposta,
                DataDoEvento = declaracaoDeSaude.DataDoEvento

            };
        }

       public static List<DeclaracaoDeSaudeDTO> Converter(List<DeclaracaoDeSaude> declaracaoDeSaudes)
        {
            return declaracaoDeSaudes.Select(x => Converter(x)).ToList();

        }
    }
}
