using DesafioCB.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Application.Validations
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(ValidationMessages.RequiredMessage)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLengthMessage);

            RuleFor(x => x.Preco)
                .NotNull().WithMessage(ValidationMessages.RequiredMessage);

            RuleFor(x => x.Quantidade)
                .NotNull().WithMessage(ValidationMessages.RequiredMessage);

            RuleFor(x => x.DataCadastro)
                .NotNull().WithMessage(ValidationMessages.RequiredMessage)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(ValidationMessages.FutureDateMessage);
        }
    }

    public static class ValidationMessages
    {
        public const string RequiredMessage = "O campo {PropertyName} é obrigatório.";
        public const string MaxLengthMessage = "O campo {PropertyName} não pode ter mais de {MaxLength} caracteres.";
        public const string FutureDateMessage = "O campo {PropertyName} não pode ser no futuro.";
    }
}
