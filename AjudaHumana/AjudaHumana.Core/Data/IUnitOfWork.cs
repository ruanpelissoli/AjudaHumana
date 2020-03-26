using System.Threading.Tasks;

namespace AjudaHumana.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}