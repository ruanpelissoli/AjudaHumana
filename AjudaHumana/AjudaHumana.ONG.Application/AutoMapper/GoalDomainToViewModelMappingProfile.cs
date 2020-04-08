using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;

namespace AjudaHumana.ONG.Application.AutoMapper
{
    public class GoalDomainToViewModelMappingProfile : Profile
    {
        public GoalDomainToViewModelMappingProfile()
        {
            CreateMap<Goal, GoalViewModel>()
                .ForMember(d => d.GoalId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.RequestId, o => o.MapFrom(s => s.RequestId))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemName))
                .ForMember(d => d.CurrentGoal, o => o.MapFrom(s => s.CurrentGoal))
                .ForMember(d => d.FinishedGoal, o => o.MapFrom(s => s.FinishedGoal))
                .ForMember(d => d.Finished, o => o.MapFrom(s => s.Finished));

            CreateMap<Request, RequestViewModel>();
        }
    }
}
