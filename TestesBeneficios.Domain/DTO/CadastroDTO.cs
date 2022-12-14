using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.DTO
{
    public class CadastroDTO

    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Compare("Senha",ErrorMessage ="Senhas não Conferem")]
        public string ConfirmacaoSenha{ get; set; }

    }
}
