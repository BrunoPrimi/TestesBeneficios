using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.DTO
{
    public class EmpresaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        public DateTime DataCriacao { get; set; }

        public virtual List<Produto> Produtos { get; set; }

    }
}
