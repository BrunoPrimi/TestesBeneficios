using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class SimulacaoDistribuicaoVida
    {
       
        public Guid Id { get; set; }

        public string AlcanceInicial { get; set; }

        public string AlcanceFinal { get; set; }

        public int Quantidade { get; set; }
        public Guid IdSimulacao { get; set; }
        public virtual Simulacao Simulacao { get; set; }
    }
}
