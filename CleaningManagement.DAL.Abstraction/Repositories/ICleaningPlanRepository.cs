using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleaningManagement.DAL.Abstraction.Entities;

namespace CleaningManagement.DAL.Abstraction.Repositories
{
    public interface ICleaningPlanRepository
    {
        void Add(CleaningPlan cleaningPlan);
        void Update(CleaningPlan cleaningPlan);
        Task DeleteAsync(Guid id);
        Task<CleaningPlan> GetByIdAsync(Guid id);
        Task<IEnumerable<CleaningPlan>> GetAllByCustomerIdAsync(int customerId);
        Task<IEnumerable<CleaningPlan>> GetAllAsync();
        Task SaveChangesAsync();
    }
}