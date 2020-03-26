using AjudaHumana.Core.Messages;
using AjudaHumana.Core.Messages.CommonMessages.Notification;
using System.Threading.Tasks;

namespace AjudaHumana.Core.Communication
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evt) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
