using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class SimulacaoAbrangencia
    {
       
        public Guid Id { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public Guid IdSimulacao { get; set; }
        public virtual Simulacao Simulacao { get; set; }
    }
}
