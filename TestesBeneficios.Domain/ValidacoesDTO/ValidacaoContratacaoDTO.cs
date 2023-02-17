using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;

namespace TestesBeneficios.Domain.ValidacoesDTO
{
    public class ValidacaoContratacaoDTO : AbstractValidator<ContratacaoDTO>
    {
        public ValidacaoContratacaoDTO() {

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
                .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Email)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Cpf)
             .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
             .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
             .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.DataDeNacimento)
             .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
             .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");

            RuleFor(x => x.Genero)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");

            RuleFor(x => x.EstadoCivil)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");

            RuleFor(x => x.DataExpedicaoRG)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!");

            RuleFor(x => x.Rg)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.OrgaoEmissor)
             .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
             .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
             .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.NomeDaMae)
             .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
             .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
             .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Celular)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Cep)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Logradouro)
                .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
                .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Numero)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Complemento)
             .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Bairro)
         .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
         .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Cidade)
              .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
              .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

            RuleFor(x => x.Cidade)
             .NotNull().WithMessage("{PropertyName} não pode ser nulo!")
             .NotEmpty().WithMessage("{PropertyName} não pode ser vázio!")
              .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres!");

        }


    }
  


    }

