using System.ComponentModel.DataAnnotations;

namespace AjudaHumana.Core.ViewModels
{
    public class AddressViewModel
    {
        [Display(Name = "Estado:")]
        public string State { get; set; }
        [Display(Name = "Cidade:")]
        public string City { get; set; }
        [Display(Name = "CEP:")]
        public string ZipCode { get; set; }
        [Display(Name = "Endereço:")]
        public string Street { get; set; }
        [Display(Name = "Número:")]
        public int Number { get; set; }
        [Display(Name = "Bairro:")]
        public string Neighbourhood { get; set; }
        [Display(Name = "Complemento:")]
        public string Complement { get; set; }

        public override string ToString()
        {
            return $"{Street}, {Number}, {City}, {State}, Brazil";
        }
    }
}
