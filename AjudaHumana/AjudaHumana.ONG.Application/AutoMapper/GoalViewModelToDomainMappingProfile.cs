using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;

namespace AjudaHumana.ONG.Application.AutoMapper
{
    public class GoalViewModelToDomainMappingProfile : Profile
    {
        public GoalViewModelToDomainMappingProfile()
        {
            CreateMap<GoalViewModel, Goal>()
                .ConstructUsing(p =>
                    new Goal(p.ItemName, p.CurrentGoal, p.FinishedGoal, p.RequestId));
        }
    }
}
