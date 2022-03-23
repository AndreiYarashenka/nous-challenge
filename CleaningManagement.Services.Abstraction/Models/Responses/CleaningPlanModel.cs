using System;

namespace CleaningManagement.Services.Abstraction.Models.Responses
{
    public class CleaningPlanModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}