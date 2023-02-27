using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBeneficios.Domain.Entidades
{
    public class Pagamento
    {
       
        public Guid Id { get; set; }

        public string ChavePix { get; set; }

        public string Banco { get; set; }

        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Digito { get; set; }
        public string TipoDeConta { get; set; }

        public int Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public string CodSeguranca { get; set; }

    }
}
