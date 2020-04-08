using AjudaHumana.Core.Utils;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;

namespace AjudaHumana.ONG.Application.AutoMapper
{
    public class ONGDomainToViewModelMappingProfile : Profile
    {
        public ONGDomainToViewModelMappingProfile()
        {
            CreateMap<NonGovernamentalOrganization, ONGViewModel>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CNPJ, o => o.MapFrom(s => s.CNPJ.RemoveSpecialCharacters()))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.ResponsibleName, o => o.MapFrom(s => s.Responsible.Name))
                .ForMember(d => d.ResponsibleCPF, o => o.MapFrom(s => s.Responsible.CPF.RemoveSpecialCharacters()))
                .ForMember(d => d.ResponsibleEmail, o => o.MapFrom(s => s.Responsible.Email))
                .ForMember(d => d.ResponsiblePhoneNumber, o => o.MapFrom(s => s.Responsible.PhoneNumber.RemoveSpecialCharacters()))
                .ForMember(d => d.AddressState, o => o.MapFrom(s => s.Address.State))
                .ForMember(d => d.AddressCity, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.AddressZipCode, o => o.MapFrom(s => s.Address.ZipCode.RemoveSpecialCharacters()))
                .ForMember(d => d.AddressStreet, o => o.MapFrom(s => s.Address.Street))
                .ForMember(d => d.AddressNumber, o => o.MapFrom(s => s.Address.Number))
                .ForMember(d => d.AddressComplement, o => o.MapFrom(s => s.Address.Complement))
                .ForMember(d => d.AddressNeighborhood, o => o.MapFrom(s => s.Address.Neighborhood))
                .ForMember(d => d.AddressLatitude, o => o.MapFrom(s => s.Address.Latitude))
                .ForMember(d => d.AddressLongitude, o => o.MapFrom(s => s.Address.Longitude))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(d => d.Approved, o => o.MapFrom(s => s.Approved));

            CreateMap<NonGovernamentalOrganization, ONGViewModel>();
        }
    }
}
