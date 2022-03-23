using AutoMapper;
using CleaningManagement.Api.Models;
using CleaningManagement.Services.Abstraction.Models.Requests;
using CleaningManagement.Services.Abstraction.Models.Responses;

namespace CleaningManagement.Api.Profiles
{
    public class CleaningPlanProfile : Profile
    {
        public CleaningPlanProfile()
        {
            CreateMap<CreateCleaningPlanRequest, CreateCleaningPlanModel>();
            CreateMap<UpdateCleaningPlanRequest, UpdateCleaningPlanModel>();

            CreateMap<CleaningPlanModel, CleaningPlanResponse>();
        }
    }
}