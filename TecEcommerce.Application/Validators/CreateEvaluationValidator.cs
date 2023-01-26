using FluentValidation;
using TecEcommerce.Application.InputModels;

namespace TecEcommerce.Application.Validators
{
    public class CreateEvaluationValidator : AbstractValidator<EvaluationInputModel>
    {
        public CreateEvaluationValidator()
        {
            RuleFor(e => e.Evalution)
                .IsInEnum();
        }
    }
}
