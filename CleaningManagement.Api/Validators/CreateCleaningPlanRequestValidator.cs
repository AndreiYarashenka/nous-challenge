using CleaningManagement.Api.Models;
using FluentValidation;

namespace CleaningManagement.Api.Validators
{
    public class CreateCleaningPlanRequestValidator: AbstractValidator<CreateCleaningPlanRequest>
    {
        public CreateCleaningPlanRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(256);
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.Description).MaximumLength(512);
        }
    }
}