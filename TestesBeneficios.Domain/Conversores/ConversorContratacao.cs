using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorContratacao
    {
        public static Contratacao Converter(Guid id, ContratacaoDTO contratacaoDTO)
        {
            return new Contratacao
            {
                Id = id,
                Nome = contratacaoDTO.Nome,
                Email = contratacaoDTO.Email,
                Cpf = contratacaoDTO.Cpf, 
                DataDeNacimento= contratacaoDTO.DataDeNacimento,
                Genero= contratacaoDTO.Genero,
                EstadoCivil = contratacaoDTO.EstadoCivil,
                NomeDaMae = contratacaoDTO.NomeDaMae,
                Rg = contratacaoDTO.Rg,
                OrgaoEmissor = contratacaoDTO.OrgaoEmissor,
                DataExpedicaoRG = contratacaoDTO.DataExpedicaoRG,
                CartaoSUS = contratacaoDTO.CartaoSUS,
                Celular = contratacaoDTO.Celular,
                Cep = contratacaoDTO.Cep,
                Logradouro = contratacaoDTO.Logradouro,
                Numero = contratacaoDTO.Numero,
                Complemento = contratacaoDTO.Complemento,
                Bairro = contratacaoDTO.Bairro,
                Cidade = contratacaoDTO.Cidade,
                Uf = contratacaoDTO.Uf

               
            };
        }
        public static ContratacaoDTO Converter(Contratacao contratacao)
        {
            return new ContratacaoDTO
            {
                Id = contratacao.Id,
                Nome = contratacao.Nome,
                Email = contratacao.Email,
                Cpf = contratacao.Cpf,
                DataDeNacimento = contratacao.DataDeNacimento,
                Genero = contratacao.Genero,
                EstadoCivil = contratacao.EstadoCivil,
                NomeDaMae = contratacao.NomeDaMae,
                Rg = contratacao.Rg,
                OrgaoEmissor = contratacao.OrgaoEmissor,
                DataExpedicaoRG = contratacao.DataExpedicaoRG,
                CartaoSUS = contratacao.CartaoSUS,
                Celular = contratacao.Celular,
                Cep = contratacao.Cep,
                Logradouro = contratacao.Logradouro,
                Numero = contratacao.Numero,
                Complemento = contratacao.Complemento,
                Bairro = contratacao.Bairro,
                Cidade = contratacao.Cidade,
                Uf = contratacao.Uf

            };
        }

        public static List<ContratacaoDTO> Converter(List<Contratacao> contratacaos)
        {
            return contratacaos.Select(x => Converter(x)).ToList();

        }




    }
}
