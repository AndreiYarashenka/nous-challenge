using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleaningManagement.Services.Abstraction.Models.Requests;
using CleaningManagement.Services.Abstraction.Models.Responses;

namespace CleaningManagement.Services.Abstraction.Services
{
    public interface ICleaningPlanService
    {
        Task<CleaningPlanModel> AddAsync(CreateCleaningPlanModel model);
        Task<CleaningPlanModel> UpdateAsync(UpdateCleaningPlanModel model);
        Task<IEnumerable<CleaningPlanModel>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<CleaningPlanModel>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}