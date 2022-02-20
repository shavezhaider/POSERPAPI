using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Repository.EDMX;

namespace POSERPAPI.Manager.Command.Account
{
   public class UserAuthenticationCommand : IRequest<AppUser>
    {
        public UserAuthenticationRequest authenticationRequest;
        public UserAuthenticationCommand(UserAuthenticationRequest userAuthenticationRequest)
        {
            authenticationRequest = userAuthenticationRequest;
        }

    }
}
