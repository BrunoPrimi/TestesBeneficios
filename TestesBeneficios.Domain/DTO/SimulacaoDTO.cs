
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.DTO
{
    public class SimulacaoDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage="Campo Obrigatorio")]
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
