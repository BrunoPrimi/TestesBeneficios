using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorEntidadeDeClasse
    {
        public static EntidadeDeClasse Converter(Guid id, EntidadeDeClasseDTO entidadeDeClasseDTO)
        {
            return new EntidadeDeClasse
            {
                Id = id,
                Cnpj = entidadeDeClasseDTO.Cnpj,
                RazaoSocial = entidadeDeClasseDTO.RazaoSocial,
                NomeFantasia = entidadeDeClasseDTO.NomeFantasia,
                Apelido = entidadeDeClasseDTO.Apelido
            };
        }

        public static EntidadeDeClasseDTO Converter(EntidadeDeClasse entidadeDeClasse)
        {
            if(entidadeDeClasse == null)
            {
                return null;
            }
            return new EntidadeDeClasseDTO
            {
                Id = entidadeDeClasse.Id,
                Cnpj = entidadeDeClasse.Cnpj,
                RazaoSocial = entidadeDeClasse.RazaoSocial,
                NomeFantasia = entidadeDeClasse.NomeFantasia,
                Apelido = entidadeDeClasse.Apelido

            };
        }

       public static List<EntidadeDeClasseDTO> Converter(List<EntidadeDeClasse> entidadeDeClasse)
        {
            return entidadeDeClasse.Select(x => Converter(x)).ToList();

        }
    }
}
