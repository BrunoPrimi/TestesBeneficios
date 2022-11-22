using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class Beneficiario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }
    }
}
