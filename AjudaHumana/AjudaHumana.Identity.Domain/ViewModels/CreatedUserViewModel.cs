using AjudaHumana.Core.Domain;

namespace AjudaHumana.Identity.Domain.ViewModels
{
    public class CreatedUserViewModel
    {
        public ApplicationUser User { get; set; }
        public string TempPassword { get; set; }
    }
}
