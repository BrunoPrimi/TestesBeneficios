﻿using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Enumeradores;
using TestesBeneficios.Domain.ValidacoesDTO;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.ComponentModel.DataAnnotations;

namespace TestesBeneficios.Domain.DTO
{
    public class SimulacaoAbrangenciaDTO
    {

        public Guid Id { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public Guid IdSimulacao { get; set; }
        public SimulacaoDTO Simulacao { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool EhValido()
        {
            var erros = new ValidacaoSimulacaoAbrangenciaDTO().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
    
