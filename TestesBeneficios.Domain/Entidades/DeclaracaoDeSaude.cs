using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Enumeradores;

namespace TestesBeneficios.Domain.Entidades
{
    public class DeclaracaoDeSaude
    {
       
        public Guid Id { get; set; }

        public Resposta Resposta { get; set; }

        public string Peso { get; set; }

        public string Altura { get; set; }

        public string Detalhes { get; set; }

        public DateTime DataDoEvento { get; set; }

    }
}
