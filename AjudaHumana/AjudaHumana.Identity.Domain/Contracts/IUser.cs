using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaHumana.Identity.Domain.Contracts
{
    public interface IUser
    {
        string UserName { get; }
        bool IsInRole(string role);
    }
}
