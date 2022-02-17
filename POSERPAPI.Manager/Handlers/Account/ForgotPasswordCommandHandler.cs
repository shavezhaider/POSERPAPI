using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Command.Account;
using POSERPAPI.Manager.Interface;

namespace POSERPAPI.Manager.Handlers.Account
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
    {
        public IUser _userManger;
        public ForgotPasswordCommandHandler(IUser userManager)
        {
            _userManger = userManager;
        }
        public Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            return _userManger.ForgotPassword(request.passwordRequest);
        }
    }
}
