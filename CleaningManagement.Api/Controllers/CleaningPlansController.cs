using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleaningManagement.Api.Models;
using CleaningManagement.Services.Abstraction.Models.Requests;
using CleaningManagement.Services.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleaningManagement.Api.Controllers
{
    [ApiController]
    [Route("api/cleaning-plans")]
    public class CleaningPlansController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICleaningPlanService _cleaningPlanService;
        
        public CleaningPlansController(
            IMapper mapper,
            ICleaningPlanService cleaningPlanService)
        {
            _mapper = mapper;
            _cleaningPlanService = cleaningPlanService;
        }

        [HttpGet]
        public async Task<IActionResult>  GetCleaningPlans()
        {
            var result = await _cleaningPlanService.GetAllAsync();
            return Ok<IEnumerable<CleaningPlanResponse>>(result);
        }
        
        [HttpGet("by-customer-id/{customerId}")]
        public async Task<IActionResult>  GetCleaningPlansByCustomerId(int customerId)
        {
            var result = await _cleaningPlanService.GetByCustomerIdAsync(customerId);
            return Ok<IEnumerable<CleaningPlanResponse>>(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCleaningPlan([FromBody] CreateCleaningPlanRequest request)
        {
            var model = _mapper.Map<CreateCleaningPlanModel>(request);

            var result = await _cleaningPlanService.AddAsync(model);
            
            return Ok<CleaningPlanResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult>  UpdateCleaningPlan(Guid id, [FromBody] UpdateCleaningPlanRequest request)
        {
            var model = _mapper.Map<UpdateCleaningPlanModel>(request);
            model.Id = id;
            
            var result = await _cleaningPlanService.UpdateAsync(model);
            
            return Ok<CleaningPlanResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCleaningPlan(Guid id)
        {
            await _cleaningPlanService.DeleteAsync(id);
            var result = await _cleaningPlanService.GetAllAsync();
            
            return Ok<IEnumerable<CleaningPlanResponse>>(result);
        }

        private IActionResult Ok<T>(object result) => Ok(_mapper.Map<T>(result));
    }
}