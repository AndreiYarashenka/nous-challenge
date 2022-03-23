using CleaningManagement.Api.Models;
using FluentValidation;

namespace CleaningManagement.Api.Validators
{
    public class UpdateCleaningPlanRequestValidator: AbstractValidator<UpdateCleaningPlanRequest>
    {
        public UpdateCleaningPlanRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(256);
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.Description).MaximumLength(512);
        }
    }
}