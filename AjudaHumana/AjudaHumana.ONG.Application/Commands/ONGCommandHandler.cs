using AjudaHumana.Core.Communication;
using AjudaHumana.Core.Messages;
using AjudaHumana.Core.Messages.CommonMessages.Notification;
using AjudaHumana.ONG.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Application.Commands
{
    public class ONGCommandHandler :
        IRequestHandler<CreateONGCommand, bool>
    {
        private readonly IONGRepository _ongRepository;
        private readonly IMediatorHandler _mediatrHandler;

        public ONGCommandHandler(IONGRepository ongRepository,
                                 IMediatorHandler mediatrHandler)
        {
            _ongRepository = ongRepository;
            _mediatrHandler = mediatrHandler;
        }


        public Task<bool> Handle(CreateONGCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private bool ValidateCommand(Command message)
        {
            if (message.IsValid()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatrHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
