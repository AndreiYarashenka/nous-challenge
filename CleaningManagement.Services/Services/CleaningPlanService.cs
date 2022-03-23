using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleaningManagement.DAL.Abstraction.Entities;
using CleaningManagement.DAL.Abstraction.Repositories;
using CleaningManagement.Services.Abstraction.Models.Requests;
using CleaningManagement.Services.Abstraction.Models.Responses;
using CleaningManagement.Services.Abstraction.Services;

namespace CleaningManagement.Services.Services
{
    public class CleaningPlanService : ICleaningPlanService
    {
        private readonly IMapper _mapper;
        private readonly ICleaningPlanRepository _cleaningPlanRepository;
        
        public CleaningPlanService(
            IMapper mapper,
            ICleaningPlanRepository cleaningPlanRepository
            )
        {
            _mapper = mapper;
            _cleaningPlanRepository = cleaningPlanRepository;
        }

        public async Task<CleaningPlanModel> AddAsync(CreateCleaningPlanModel model)
        {
            var cleaningPlan = _mapper.Map<CleaningPlan>(model);
            
            _cleaningPlanRepository.Add(cleaningPlan);
            await SaveChangesAsync();

            return _mapper.Map<CleaningPlanModel>(cleaningPlan);
        }
        
        public async Task<CleaningPlanModel> UpdateAsync(UpdateCleaningPlanModel model)
        {
            var cleaningPlan = _mapper.Map<CleaningPlan>(model);

            var entity = await _cleaningPlanRepository.GetByIdAsync(cleaningPlan.Id);
            cleaningPlan.CreationDate = entity.CreationDate;
            
            _cleaningPlanRepository.Update(cleaningPlan);
            await SaveChangesAsync();

            return _mapper.Map<CleaningPlanModel>(cleaningPlan);
        }
        
        public async Task<IEnumerable<CleaningPlanModel>> GetByCustomerIdAsync(int customerId)
        {
            var cleaningPlans = await _cleaningPlanRepository.GetAllByCustomerIdAsync(customerId);

            return _mapper.Map<IEnumerable<CleaningPlanModel>>(cleaningPlans);
        }

        public async Task<IEnumerable<CleaningPlanModel>> GetAllAsync()
        {
            var cleaningPlans = await _cleaningPlanRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CleaningPlanModel>>(cleaningPlans);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _cleaningPlanRepository.DeleteAsync(id);
            await SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _cleaningPlanRepository.SaveChangesAsync();
        }
    }
}