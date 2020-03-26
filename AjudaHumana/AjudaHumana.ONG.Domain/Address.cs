using AjudaHumana.Core.Domain;

namespace AjudaHumana.ONG.Domain
{
    public class Address : BaseEntity
    {
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public virtual NonGovernamentalOrganization ONG { get; set; }

        protected Address() { }
    }
}
