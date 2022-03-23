namespace CleaningManagement.Services.Abstraction.Models.Requests
{
    public record CreateCleaningPlanModel(string Title, int CustomerId, string Description);
}