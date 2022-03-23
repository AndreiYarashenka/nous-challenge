using System;

namespace CleaningManagement.Services.Abstraction.Models.Requests
{
    public class UpdateCleaningPlanModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
    }
}