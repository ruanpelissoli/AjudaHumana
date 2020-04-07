using AjudaHumana.Core.Domain;
using AjudaHumana.Core.Utils;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjudaHumana.ONG.Domain
{
    public class NonGovernamentalOrganization : BaseEntity, IAggregateRoot
    {
        public Guid ResponsibleId { get; private set; }
        public Guid AddressId { get; private set; }
        public string Name { get; private set; }
        public string CNPJ { get; set; }
        public string Description { get; private set; }
        public bool? Approved { get; private set; }

        [ForeignKey("ResponsibleId")]
        public virtual Responsible Responsible { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        protected NonGovernamentalOrganization() { }
        public NonGovernamentalOrganization(string name, string cnpj, string description, Responsible responsible, Address address)
        {
            Name = name;
            CNPJ = cnpj.RemoveSpecialCharacters();
            Description = description;
            Approved = false;
            IsActive = true;

            Responsible = responsible;
            Address = address;
        }

        public void Approve() => Approved = true;
        public void Disapprove() => Approved = false;
        public void Deactivate() => IsActive = false;

        public void SetResponsible(Responsible responsible)
        {
            Responsible = responsible;
            ResponsibleId = responsible.Id;
        }

        public void SetAddress(Address address)
        {
            Address = address;
            AddressId = address.Id;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }
    }
}
