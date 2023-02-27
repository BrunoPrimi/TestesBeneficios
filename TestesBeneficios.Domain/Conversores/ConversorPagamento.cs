using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Convercores
{
    public static class ConversorPagamento
    {
        public static Pagamento Converter(Guid id, PagamentoDTO pagamentoDTO)
        {
            return new Pagamento
            {
                Id = id,
                Agencia = pagamentoDTO.Agencia,
                Numero = pagamentoDTO.Numero,
                ChavePix = pagamentoDTO.ChavePix,
                CodSeguranca = pagamentoDTO.CodSeguranca,
                Banco = pagamentoDTO.Banco,
                Digito = pagamentoDTO.Digito,
                TipoDeConta = pagamentoDTO.TipoDeConta,
                Conta = pagamentoDTO.Conta,
                Vencimento = pagamentoDTO.Vencimento
                

            };
        }

        public static PagamentoDTO Converter(Pagamento pagamento)
        {
            return new PagamentoDTO
            {
                Id = pagamento.Id,
                Agencia = pagamento.Agencia,
                Numero = pagamento.Numero,
                ChavePix = pagamento.ChavePix,
                CodSeguranca = pagamento.CodSeguranca,
                Banco = pagamento.Banco,
                Digito = pagamento.Digito,
                TipoDeConta = pagamento.TipoDeConta,
                Conta = pagamento.Conta,
                Vencimento = pagamento.Vencimento

            };
        }

       public static List<PagamentoDTO> Converter(List<Pagamento> pagamentos)
        {
            return pagamentos.Select(x => Converter(x)).ToList();

        }
    }
}
