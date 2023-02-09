
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Enumeradores;

namespace TestesBeneficios.Domain.Entidades
{
    public class Contratacao
    {
       
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNacimento { get; set; }
        public Genero? Genero { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string NomeDaMae { get; set; }
        public string Rg { get; set; }
        public string   OrgaoEmissor { get; set; }
        public DateTime DataExpedicaoRG { get; set; }
        public string CartaoSUS { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }







    }
}
