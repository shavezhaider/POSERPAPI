using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Command.Account;
using POSERPAPI.Manager.Implementation;
using POSERPAPI.Manager.Interface;

namespace POSERPAPI.Manager.Handlers.Account
{
    public class AppUserCommandHandler : IRequestHandler<AppUserCommand, AppUserResponse>
    {
        public IUser _userManger;
        public AppUserCommandHandler(IUser userManager)
        {
            _userManger = userManager;
        }
        public Task<AppUserResponse> Handle(AppUserCommand request, CancellationToken cancellationToken)
        {
           return  _userManger.AddUser(request.appUserRequest);
           // throw new NotImplementedException();
        }
    }
}
