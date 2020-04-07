﻿using AjudaHumana.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace AjudaHumana.Identity.Domain
{
    public class ApplicationUser : IdentityUser, IAggregateRoot
    {
        protected ApplicationUser() { }

        public ApplicationUser(string email)
        {
            UserName = email;
            Email = email;
            ChangePassword = true;
        }

        public bool ChangePassword { get; private set; }

        public void PasswordResetted()
        {
            ChangePassword = false;
        }
    }    
}
