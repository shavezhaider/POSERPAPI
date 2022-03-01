using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Manager.Command.Account;
using POSERPAPI.Manager.Interface;

namespace POSERPAPI.Manager.Handlers.Account
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ProcessingStatusEntity>
    {
        public IUser _userManger;
        public ResetPasswordCommandHandler(IUser userManager)
        {
            _userManger = userManager;
        }
        public Task<ProcessingStatusEntity> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            return _userManger.ResetPassword(request.resetPassword);
        }
    }
}
