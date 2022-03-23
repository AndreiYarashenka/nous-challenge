namespace CleaningManagement.Api.Models
{
    public record CreateCleaningPlanRequest(string Title, int CustomerId, string Description);
}