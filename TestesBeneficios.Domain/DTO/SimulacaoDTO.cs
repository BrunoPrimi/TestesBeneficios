
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Enumeradores;
using TestesBeneficios.Domain.ValidacoesDTO;
using static TestesBeneficios.Domain.Entidades.Simulacao;

namespace TestesBeneficios.Domain.DTO
{
    public class SimulacaoDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        public string Cpf { get; set; }
        public AbrangenciaProduto? AbrangenciaProduto { get; set; }

        public Guid? IdProfissao { get; set; }
        public ProfissaoDTO Profissao { get; set; }

        public Guid? IdEntidadeDeClasse { get; set; }
        public EntidadeDeClasseDTO EntidadeDeClasse { get; set; }
        public virtual List<SimulacaoDistribuicaoVidaDTO> SimulacaoDistribuicaoVida { get; set; }
        public virtual List<SimulacaoAbrangenciaDTO> SimulacaoAbrangencia { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public bool EhValido()
        {
            var erros = new ValidacaoSimulacaoDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
        public bool EhValido_Distribuicao()
        {
            var erros = new ValidacaoSimulacao_DistribuicaoDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
