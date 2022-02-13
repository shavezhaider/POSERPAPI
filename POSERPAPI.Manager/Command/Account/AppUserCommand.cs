using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;

namespace POSERPAPI.Manager.Command.Account
{
    public class AppUserCommand : IRequest<AppUserResponse>
    {
        public AppUserRequest appUserRequest;
        public AppUserCommand(AppUserRequest _appUserRequest)
        {
            appUserRequest = _appUserRequest;
        }
    }
}
