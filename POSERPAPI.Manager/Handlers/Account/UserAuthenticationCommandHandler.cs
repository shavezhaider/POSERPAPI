using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Command.Account;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Repository.EDMX;

namespace POSERPAPI.Manager.Handlers.Account
{
    public class UserAuthenticationCommandHandler : IRequestHandler<UserAuthenticationCommand, AppUser>
    {
        IUser _user;
        public UserAuthenticationCommandHandler(IUser user)
        {
            _user = user;

        }
        public Task<AppUser> Handle(UserAuthenticationCommand request, CancellationToken cancellationToken)
        {
           return  _user.GetUserAuthenticationToken(request.authenticationRequest);           
        }      


    }
}
