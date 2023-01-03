using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorEmpresa
    {
        public static Empresa Converter (Guid id, EmpresaDTO empresaDTO)
        {
            return new Empresa {
                Id=id,
                Cnpj=empresaDTO.Cnpj,
                RazaoSocial=   empresaDTO.RazaoSocial,
                NomeFantasia=empresaDTO.NomeFantasia,
                DataCriacao = empresaDTO.DataCriacao
            };
        }

    }
}
