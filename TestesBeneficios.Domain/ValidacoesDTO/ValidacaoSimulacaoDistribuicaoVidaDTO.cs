﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.ValidacoesDTO
{
    public class ValidacaoSimulacaoDistribuicaoVidaDTO : AbstractValidator<SimulacaoDistribuicaoVidaDTO>
    {
        public ValidacaoSimulacaoDistribuicaoVidaDTO  () {

            RuleFor(x => x.AlcanceInicial)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
                .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.AlcanceFinal)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
                .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");
        }
    }
}
