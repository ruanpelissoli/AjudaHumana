using System;

namespace AjudaHumana.Core.Domain
{
    public interface IUser
    {
        string UserName { get; }
        Guid? Id { get; }
        bool IsInRole(string role);
    }
}
