using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningManagement.DAL.Abstraction.Entities;
using CleaningManagement.DAL.Abstraction.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleaningManagement.DAL.Repositories
{
    public class CleaningPlanRepository: ICleaningPlanRepository
    {
        private readonly CleaningManagementDbContext _dbContext;
        private readonly DbSet<CleaningPlan> _dbSet;
        
        public CleaningPlanRepository(CleaningManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<CleaningPlan>();
        }

        public void Add(CleaningPlan cleaningPlan)
        {
            cleaningPlan.CreationDate = DateTime.UtcNow;
            _dbSet.Add(cleaningPlan);
        }

        public void Update(CleaningPlan cleaningPlan)
        {
            _dbSet.Update(cleaningPlan);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is not null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<CleaningPlan> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CleaningPlan>> GetAllByCustomerIdAsync(int customerId)
        {
            return await _dbSet.Where(x => x.CustomerId == customerId).ToListAsync();
        }
        
        public async Task<IEnumerable<CleaningPlan>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}