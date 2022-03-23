using System;

namespace CleaningManagement.Api.Models
{
    public class CleaningPlanResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}