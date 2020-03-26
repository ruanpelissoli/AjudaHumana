using AjudaHumana.Core.Domain;

namespace AjudaHumana.ONG.Domain
{
    public class Responsible : BaseEntity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual NonGovernamentalOrganization ONG { get; set; }

        protected Responsible() { }
    }
}
