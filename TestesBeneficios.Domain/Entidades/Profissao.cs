using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class Profissao
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }


        public DateTime DataCriacao { get; set; }


    }
}
