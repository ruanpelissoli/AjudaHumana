using AjudaHumana.Core.Domain;
using System;

namespace AjudaHumana.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
