using AutoMapper;
using CleaningManagement.DAL.Abstraction.Entities;
using CleaningManagement.Services.Abstraction.Models.Requests;
using CleaningManagement.Services.Abstraction.Models.Responses;

namespace CleaningManagement.Services.Profiles
{
    public class CleaningPlanProfile : Profile
    {
        public CleaningPlanProfile()
        {
            CreateMap<CreateCleaningPlanModel, CleaningPlan>();
            CreateMap<UpdateCleaningPlanModel, CleaningPlan>();
            
            CreateMap<CleaningPlan, CleaningPlanModel>()
                .ForMember(
                    x => x.CreatedAt, 
                    opt => opt.MapFrom(x => x.CreationDate));

        }
    }
}