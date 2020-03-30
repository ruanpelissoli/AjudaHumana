using AjudaHumana.Core.Utils;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;

namespace AjudaHumana.ONG.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ONGViewModel, NonGovernamentalOrganization>()
                .ConstructUsing(p =>
                    new NonGovernamentalOrganization(p.Name, p.CNPJ.RemoveSpecialCharacters(), p.Description,
                    new Responsible(p.ResponsibleName, p.ResponsibleCPF.RemoveSpecialCharacters(), p.ResponsibleEmail, p.ResponsiblePhoneNumber),
                    new Address(p.AddressState, p.AddressCity, p.AddressZipCode, p.AddressStreet, p.AddressNumber, p.AddressComplement, p.AddressNeighborhood)));
        }
    }
}
