using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class EntidadeDeClasse
    {
        public Guid Id { get; set; }

       
        public string Cnpj { get; set; }

        
        public string RazaoSocial { get; set; }

      
        public string NomeFantasia { get; set; }

        public string Apelido { get; set; }


    }
}
