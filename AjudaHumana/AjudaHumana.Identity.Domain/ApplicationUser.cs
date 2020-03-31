using Microsoft.AspNetCore.Identity;

namespace AjudaHumana.Identity.Domain
{
    public class ApplicationUser : IdentityUser
    {
        protected ApplicationUser() { }

        public ApplicationUser(string email)
        {
            UserName = email;
            Email = email;
        }
    }    
}
