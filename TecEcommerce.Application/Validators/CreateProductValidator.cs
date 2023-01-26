using FluentValidation;
using TecEcommerce.Application.InputModels;
using TecEcommerce.Core.Entities;
using TecEcommerce.Core.Enums;

namespace TecEcommerce.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductInputModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("O nome do produto deve ser preenchido!")
                .NotEmpty().WithMessage("O nome do produto deve ser preenchido!")
                .Length(3, 50).WithMessage("O nome do produto deve ter entre 3 e 50 caracteres!");

            RuleFor(p => p.Description)
                .MaximumLength(255).WithMessage("A descrição do produto deve ter no máximo 255 caracteres!");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior do que R$ 0,00");

            RuleFor(p => p.Category)
                .IsInEnum();
        }
    }
}
