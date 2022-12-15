using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.Entidades
{
    public class Usuario:   IdentityUser
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [NotMapped]
        public string SenhaUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [NotMapped]
        [Compare("SenhaUsuario", ErrorMessage = "Senhas não Conferem")]
        public string ConfirmacaoSenhaUsuario { get; set; }

    }
}
