using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class Beneficiario
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome Mãe")]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }
    }
}
