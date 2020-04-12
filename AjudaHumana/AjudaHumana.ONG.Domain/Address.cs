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
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual NonGovernamentalOrganization ONG { get; set; }

        protected Address() { }
        public Address(string state, string city, string zipCode, string street, int number, string complement, string neighborhood)
        {
            State = state;
            City = city;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
        }
    }
}
