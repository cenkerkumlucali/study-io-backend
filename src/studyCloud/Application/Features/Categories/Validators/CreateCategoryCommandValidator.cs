using Application.Features.Categories.Commands.CreateCategory;
using FluentValidation;

namespace Application.Features.Categories.Validators;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(1);
    }
}