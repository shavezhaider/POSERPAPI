using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
 

namespace POSERPAPI.Manager.Command.Account
{
   public class UserAuthenticationCommand : IRequest<IdentityUser>
    {
        public UserAuthenticationRequest authenticationRequest;
        public UserAuthenticationCommand(UserAuthenticationRequest userAuthenticationRequest)
        {
            authenticationRequest = userAuthenticationRequest;
        }

    }
}
