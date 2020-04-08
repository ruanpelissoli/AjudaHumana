using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;

namespace AjudaHumana.ONG.Application.AutoMapper
{
    public class RequestDomainToViewModelMappingProfile : Profile
    {
        public RequestDomainToViewModelMappingProfile()
        {
            CreateMap<Request, RequestViewModel>()
                .ForMember(d => d.ONGId, o => o.MapFrom(s => s.ONGId))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Finished, o => o.MapFrom(s => s.Finished ? "Sim" : "Não"))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")));

            CreateMap<Request, RequestViewModel>();
        }
    }
}
