using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;

namespace AjudaHumana.ONG.Application.AutoMapper
{
    public class RequestViewModelToDomainMappingProfile : Profile
    {
        public RequestViewModelToDomainMappingProfile()
        {
            CreateMap<RequestViewModel, Request>()
                .ConstructUsing(p =>
                    new Request(p.Description, p.ONGId));
        }
    }
}
