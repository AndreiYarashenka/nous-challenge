namespace CleaningManagement.Api.Models
{
    public record UpdateCleaningPlanRequest(string Title, int CustomerId, string Description);
}