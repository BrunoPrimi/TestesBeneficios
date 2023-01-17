
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
    public class Simulacao
    {
       
        public Guid Id { get; set; }

        public string Nome { get; set; }
      
        public string Email { get; set; }
        public string Cpf { get; set; }
        public enum Abrangencia { }

        public Guid IdProfissao{ get; set; }
        public Profissao Profissao { get; set; }

        public Guid IdEntidadeDeClasse { get; set; }
        public EntidadeDeClasse EntidadeDeClasse { get; set; }



       

        
       
    }
}
